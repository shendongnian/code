    [SerializeField] private Button MyButton = null; // assign in the editor
    public int numberoflevel;
    
    void Start() { MyButton.onClick.AddListener(() => { changeScene(numberoflevel);});
    }
    
     public void LoadScene(int SceneToChangeTo){
            Application.LoadLevel (SceneToChangeTo);
        }
