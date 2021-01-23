    /* 
    only for dev use - just checks the preload scene has run.
    if not it loads it.
    in production of coursepreload always runs.
    MUST RUN ABSOLUTELY FIRST -- GO TO SCRIPT EXECUTION ORDER
    */
    
    using UnityEngine;
    public class DevPreload:MonoBehaviour
    	{
    	void Awake()
    		{
    		GameObject check = GameObject.Find("__app");
    		// "__app" is one of your DDOL gameobjects in preload scene
    		if (check==null)
    			SceneManagement.SceneManager.LoadScene("_preload");
    		}
    	
    	}
