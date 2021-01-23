    public class SecondLevel : MonoBehaviour {
        string PrevScene;
        public void Start() {
            PrevScene = PlayerPrefs.GetString("SceneNumber");
            // if there will be a third scene, etc.
            PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
        }
        public void GoToPrevScene() {
            SceneManager.LoadScene(PrevScene);
        }
    }
