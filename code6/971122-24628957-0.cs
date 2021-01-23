    Window.Current.VisibilityChanged += (s, e) => 
    {
        if (!e.Visible)
        {
            // Application went to background
        }
        else 
        {
            // Application is FullScreen again
        }
    };
