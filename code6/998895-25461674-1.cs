    // RequiredFallingTime  is a public class field which I set in the inspector to be a little
    // bit higher than my jump time (0.7 seconds in my case)
    void Update () {
    
    	fallingCount = ( cc.isGrounded ) ? 0 : fallingCount + 1;
    
    	Debug.Log("Update: fallingCount = " + fallingCount);
    
    
    
    	fallTime = fallingCount * Time.deltaTime;
    	Debug.Log("Update: falling Duration = " + fallTime );
    
    
    	falling = ( fallTime >= RequiredFallingTime ) ? true : false;
    
    	// Still Falling: None of my Controls should produce sound while falling so return:
    	if( fallTime / 2 >= RequiredFallingTime )
    		return;
    
    	// If first time falling, play our fall sound:
    	if( falling ){
    		audioSource.PlayOneShot(audioClipsOneShot[(int)SoundOneShot.fall]);
    	}
    
    
    	// If we made it this far, we're not falling--although we could be jumping.
        // Do Input checking for approp. sounds
    
    
    
    
    }
