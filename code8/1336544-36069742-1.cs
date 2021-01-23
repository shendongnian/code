    private void Page_Load()
    {
        if (ViewState["button_was_clicked"] != null)
        {
            AddDynamicCheckBoxes();
        }
    }
    
    private void Button_OnClick()
    {
        AddDynamicCheckBoxes();
        ViewState["button_was_clicked"] = true;
    }
