    radButton1.Click += buttonClickHandler;
    radButton2.Click += buttonClickHandler;
    
    private void buttonClickHandler(object sender, EventArgs e)
    {
        var button = sender as Button;
        var action = getAction(ConfigurationManager.AppSettings[button.Text + "a"];
        
        //Execute whatever you want here based on action
    }
