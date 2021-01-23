    public delegate void ClickHandler();
    public ClickHandler OnClick;
    public void Update()
    {
        //- detect click or other action
        if(click and OnClick!= null)
        { 
            OnClick();
        }
    }
    
