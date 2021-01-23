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
    
    		if (!audio.isPlaying) 
    		{
    
    			clipIndex = Random.Range(0, clips.Length - 1);
    			audio.clip = clips[clipIndex];
    			audio.PlayDelayed(Random.Range(10f, 20f));
    			Debug.Log("Nothing playing, we set new audio to " + audio.clip.name);
    		}
    	}
    
    
