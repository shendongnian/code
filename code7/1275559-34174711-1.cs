    using UnityEngine.SceneManagement;
    
    public class Example
    {
    	public void ReloadCurrentScene()
    	{
    		// get the current scene name 
    		string sceneName = SceneManager.GetActiveScene().name;
    		// load the same scene
    		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    	}
    }
