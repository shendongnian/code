    MainViewModel _mvm = new MainViewModel();
    _mvm.messagebox_text = "what ever";
 
    messageBox = new CustomMessageBox()
    {
        ContentTemplate = (DataTemplate)this.Resources["myContentTemplate"],                
        LeftButtonContent = "speak",
        RightButtonContent = "read it",
        IsFullScreen = false
        
    };
    
    messageBox.Content = _mvm;  // set the bind
