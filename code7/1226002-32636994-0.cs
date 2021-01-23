    public event EventHandler<BackRequestedEventArgs> BackRequested;
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        // Raise child event
        var eventHandler = this.BackRequested;
        if (eventHandler != null)
        {
            eventHandler(sender, e);
        }
        if (!e.Handled)
        {
            if (_rootFrame != null && _rootFrame.CanGoBack)
            {
                e.Handled = true;
                _rootFrame.GoBack();
            }
        }
    }
