    Button[] buttons;
    
    void Start()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => levelBtnClicked(btn));
        }
    }
    
    void levelBtnClicked(Button buttonClicked)
    {
    
    }
