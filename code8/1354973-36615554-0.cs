    int waitCounter = 0;
    void ShowLoader()
    {
        waitCounter += 1;
        if (waitCounter > 1) // Already loader is visible 
            return;
    
        loading.Visibility = Windows.UI.Xaml.Visibility.Visible;
    }
    
    void HideLoader()
    {
        waitCounter -= 1;
    
        if (waitCounter <= 0) // No more call to wait for 
           loading.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
    }
