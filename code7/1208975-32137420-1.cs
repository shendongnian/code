    private async void ButtonClick(object sender, EventArgs e)
    {
        var directory = String.Empty;
        Button clickedButton = (Button)sender;
        switch (clickedButton.Name)
        {
            case "First_Button":
                directory = _ftp.GetCurrentDate(true);
                break;
            case "Second_Button":
                directory = _ftp.GetCurrentDate(false);
                break;
            case null:
                return;
        }
    
        First_Button.Enabled = false;
        Second_Button.Enabled = false;
    
        await Task.Run(() =>
        {
            // your work. you can use directory here
    
    
    
        });
    
        First_Button.Enabled = true;
        Second_Button.Enabled = true;
    
    }
