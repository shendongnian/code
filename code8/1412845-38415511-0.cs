    intercafe IShowMusicLibrary
    {
    event action show();
    }
    
    //view
    
    
    public void ShowLibraryButton_Click(object sender, EventArgs e)
    {
       if(show!=null)
    show();
    
        
    }
    
    //presenter
    private IShowMusicLibrary _musicLibrary;
    
    // in constructor
    _musicLibrary.show += YourEvent;
    
    
    public YourEvent()
    {
    //here show a child control.
    }
