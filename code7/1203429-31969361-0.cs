    using UnityEngine;
    using System.Collections;
    public class AudioController : MonoBehaviour
    {
    
    [SerializeField] private AudioClip[] clips;
    private int clipIndex;
    private AudioSource audio;
    private bool audioPlaying = false;
    
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        StartCoroutine(PlaySound());
    
    }
    
    IEnumerator PlaySound()
    {
        
        if (!audio.isPlaying)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            clipIndex = Random.Range(0, clips.Length - 1);
            audioPlaying = true;
            audio.PlayOneShot(clips[clipIndex], 1f);
        }
        yield return null;
    }
    }
