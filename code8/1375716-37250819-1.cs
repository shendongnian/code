    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame.CanGoBack)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
        //you can check for this here rootFrame.BackStack[rootFrame.BackStack.Count-1].SourcePageType.Name
    
    }
