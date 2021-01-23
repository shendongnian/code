    private bool _showLoginToolTip;
    
    public bool ShowLoginToolTip
    {
        get
           {
             return _showLoginToolTip;
           }
        set
           {
             _showLoginToolTip = value;
             OnPropertyChanged("ShowLoginTip");
           }
    }
    private void TestDebugEx()
    {
        ShowLoginTip = true;
    }
