    using UnityEngine;
    using System.Collections;
    
    public class life : MonoBehaviour {
    	int lifes;
    
    	void Awake(){
    		lifes = 3;
    		DontDestroyOnLoad(this);
    	}
    
    	public void looseLife(){
    		if (lifes != 0)
    			lifes--;
    		Debug.Log (lifes);
    	}
    
    }
