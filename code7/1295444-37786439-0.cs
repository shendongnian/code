    Window.Current.VisibilityChanged += OnVisibilityChanged;
            
    /// <summary>
    /// When the window visibility changes, the stuff happens
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">VisibilityChangedEventArgs e</param>
    private void OnVisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
    
    	if (!e.Visible)
    	{
    	   // do stuff
    	}
    	else
    	{
    	   // do other stuff
    	}
    }
