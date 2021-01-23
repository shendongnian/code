    void Start() 
    {
      GlobalCountDown.StartCountDown (TimeSpan.FromSeconds (5)); 
    }
    
    void Update() 
    {
        if (GlobalCountDown.TimeLeft == TimeSpan.Zero)
          SceneManager.LoadScene("Lose");  
    }
