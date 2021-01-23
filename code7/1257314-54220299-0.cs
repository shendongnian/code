    public class FirstLevel : MonoBehaviour {
        public void Start() {
            PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
        }
    }
