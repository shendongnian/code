    using UnityEngine;
    using UnityEngine.UI;
    public class UIController : MonoBehaviour {
    
    public int numOfSceneToLoad; // number of the scene from the build settings
    
      public void LoadSceneNumber(numOfSceneToLoad){
        UnityEngine.SceneManagement.SceneManager.LoadScene(numOfSceneToLoad);
      }
    
    }
