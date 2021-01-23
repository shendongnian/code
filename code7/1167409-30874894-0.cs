    using UnityEngine;
    using System.Collections;
    
    public class CubeTrigger : MonoBehaviour {
    
    	public ParticleSystem Flame1;
    	public ParticleSystem Flame2;
    	public ParticleSystem Flame3;
    	public ParticleSystem Flame4;
    
    	void OnTriggerEnter (Collider other) {
    
    		Flame1.Play ();
    		Flame2.Play ();
    		Flame3.Play ();
    		Flame4.Play ();
    	}
    }
