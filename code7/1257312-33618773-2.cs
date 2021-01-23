    using UnityEngine;
    using System.Collections;
    public class Indestructable : MonoBehaviour {
    	public static Indestructable instance = null;
    	
    	// For sake of example, assume -1 indicates first scene
    	public int prevScene = -1;
    
    	void Awake() {
    		// If we don't have an instance set - set it now
    		if(!instance )
    			instance = this;
    		// Otherwise, its a double, we dont need it - destroy
    		else {
    			Destroy(this.gameObject) ;
    			return;
    		}
    		
    		DontDestroyOnLoad(this.gameObject) ;
    	}
    }
