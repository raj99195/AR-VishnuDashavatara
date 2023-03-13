using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayLargeAudioClip : MonoBehaviour
{
    public AudioClip audioClip;
    public Button secondButton;
    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayAudioClip());
            // Disable the second button
            secondButton.interactable = false;
        }
    }

    private IEnumerator PlayAudioClip()
    {
        isPlaying = true;
        audioSource.clip = audioClip;
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        isPlaying = false;
        // Enable the second button once the audio has finished playing
        secondButton.interactable = true;
    }
}
