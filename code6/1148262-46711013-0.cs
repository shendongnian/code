    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class randomSound : MonoBehaviour {
    	
    
    	public AudioSource mySource;
    	public int rangeScan;
    	public AudioClip[] myAudio;
    	public int toPlay;
    	public bool debugging;
    
    	void OnEnable () {
    		toPlay = Random.Range(0,rangeScan);
    		if (debugging) {
    			foreach (AudioClip value in myAudio) {
    				print (value);
    			}
    		}
    		mySource.PlayOneShot(myAudio[toPlay], 0.9F);
    		mySource.Play ();
    	}
    }
