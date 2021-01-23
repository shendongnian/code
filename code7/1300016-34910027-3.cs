    private void AddNewBrowser()
    {
        Log("Adding New Tab and Browser");
    
        UiBrowser browser = new UiBrowser();
    
        TabPage tp = new TabPage();
    
        tp.Controls.Add(browser);
        customTabControl1.TabPages.Add(tp);
    
        if (customTabControl1.Created)
            tp.CreateControls();
    }
