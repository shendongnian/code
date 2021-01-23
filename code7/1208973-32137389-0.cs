    private void First_Button_Click(object sender, RoutedEventArgs e)
    {
        _worker.RunWorkerAsync("First_Button");
    }
    
    private void Second_Button_Click(object sender, RoutedEventArgs e)
    {
        _worker.RunWorkerAsync("Second_Button");
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string buttonName = (string)e.Argument;
    
        switch (buttonName)
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
    }
