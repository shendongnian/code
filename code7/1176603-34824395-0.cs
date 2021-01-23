    bool bIsTabletMode = false;
    
    var uiMode = UIViewSettings.GetForCurrentView().UserInteractionMode;
    
    if (uiMode == Windows.UI.ViewManagement.UserInteractionMode.Touch)
    
     bIsTabletMode = true;
    
    else
    
     bIsTabletMode = false;
    
    
    // (Could also compare with .Mouse instead of .Touch)
