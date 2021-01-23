    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame.CanGoBack)
        {
            rootFrame.GoBack();
            e.Handled = true;
        }
    }
