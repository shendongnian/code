    using UnityEngine;
    using System.Collections;
    
    public class AudioController : MonoBehaviour
    {
   	    public AudioClip[] clips;
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
    			audio.PlayDelayed(Random.Range(20f, 50f));
    			Debug.Log("Nothing playing, we set new audio to " + audio.clip.name);
    		}
    	}
    }
