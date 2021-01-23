    public Button getBtnMyButton
    {
        get
        {
            if (btnMyButton != null)
                return btnMyButton;
            
            throw new Exception("Button is null!");
        }
        set
        {
            if (value == null)
                return;
           
            btnMyButton = value;
        }
    }
