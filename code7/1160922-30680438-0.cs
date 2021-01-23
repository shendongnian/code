    [SerializeField] private Button MyButton = null; // assign in the editor
    
    void Start() { MyButton.onClick.AddListener(() => { pause();});
    }
    
    void pause(){
            if (Time.timeScale == 1)
             {
                 Time.timeScale = 0;
             }
             else
             {
                 Time.timeScale = 1;
             }
         
     }
