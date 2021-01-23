    public void SomeMethod()
    {
        ChangeWindowControlStyles();
    
        var m_dispatcher = Application.Current.Dispatcher;
    
        m_dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
        new System.Threading.ThreadStart(delegate
        {
            
            TakeScreenshotAndSave(); //Now running on UI thread
            
        }));
    }
