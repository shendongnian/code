    /* 
    ONLY FOR USE DURING DEVELOPMENT IN THE EDITOR
    just checks if the preload scene has run.
    if not ... it loads it.
    (in production, of course preload always runs.)
    MUST RUN ABSOLUTELY FIRST -- GO TO SCRIPT EXECUTION ORDER
    of course you would remove this script before building to ship
    (however, it is perfectly safe if you leave it on.)
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
