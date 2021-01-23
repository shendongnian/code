    using UnityEngine.SceneManagement;
    
    public class Example
    {
    	public void ReloadCurrentScene()
    	{
    		string sceneName = SceneManager.GetActiveScene().name;
    		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    	}
    }
