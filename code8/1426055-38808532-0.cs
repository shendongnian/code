    public class OpenCounter : MonoBehaviour
    {
        int timesPlayed;
        public Text timeSpendOnGame;
    
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            timeSpendOnGame.GetComponent<Text>();
        }
    
        void Start()
        {
            timeSpendOnGame.text = "" + timesPlayed;
        }
    
    
        public void Save()
        {
            PlayerPrefs.SetInt("timesPlayed", timesPlayed);
        }
    
        //Load
        public void Load()
        {
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
        }
    
        //Load when Opening
        public void OnEnable()
        {
            Debug.Log("Opening!");
            Load();
        }
    
        //Increment and Save on Exit
        public void OnDisable()
        {
            Debug.Log("Existing!");
            timesPlayed++; //Increment how many times opened
            Save(); //save
        }
    }
