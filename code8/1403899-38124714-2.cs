    public class GlobalControl : MonoBehaviour 
    {
        public bool muteSound;
        public static GlobalControl Instance;
    
        void Awake ()   
           {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy (gameObject);
            }
          }
    }
