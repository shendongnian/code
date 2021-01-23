    using UnityEngine;
    using System.Collections;
    
    public class ButtonTest : MonoBehaviour {
    	
    	float timeOut = 0.25f;
    	float timeLimit; // the latest time a double-press can be made
    	string lastButton; // the name of the button last checked
    
        // an example of using "CheckDouble" is in here
    	void Update (){
    		if (Input.GetKeyDown("right")) CheckDouble("right");
    	}
    
        // The function to check for double-presses of a given button
    	bool CheckDouble (string newButton) {
    		// if new button press is the same as last, AND recent enough
    		if(newButton==lastButton && Time.time<timeLimit )
    		{
    			timeLimit=Time.time; // expires the double-press
    			Debug.Log("Double Press");
    			return true;
    		}
    		else
    		{
    			timeLimit = Time.time+timeOut; // set new Limit for double-press
    			lastButton = newButton; // for future checks
    			Debug.Log("Single Press (so far)");
    			return false;
    		}
    	}
    }
