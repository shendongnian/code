    public float secondButtonDelay = 2.0f; // time in seconds for a delay
    bool isShowingButtons = false;
    float showTime;
    void Start()
    {
         ShowButtons(); // remove this if you don't want the buttons to show on start
    }
    void ShowButtons()
    {
        isShowingButtons = true;
        showTime = Time.time;
    }
    void OnGUI()
    {
         if (isShowingButtons)
         {
             GUI.Button (new Rect(400,40,45,45),"text1");
             
             if (showTime + secondButtonDelay >= Time.time)
             {
                 GUI.Button (new Rect(800,40,45,45),"text1");
             }
         }
    }
