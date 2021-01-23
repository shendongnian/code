    private void connectButtonsHandlers()
    {
        foreach(var c in this.Controls)
        {
            if(c is Button)
            {
                (c as Button).Click += buttonClickHandler;
            }
        }
    }
