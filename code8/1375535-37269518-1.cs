    public event EventHandler<BackRequestedEventArgs> BackRequested;
    
    private void App_BackRequested(object sender, BackRequestedEventArgs e)
    {
        BackRequested?.Invoke(sender, e);
    
        Frame rootFrame = Window.Current.Content as Frame;
    
        if (!e.Handled && rootFrame != null && rootFrame.CanGoBack)
        {
            rootFrame.GoBack();
            e.Handled = true;
        }
    }
