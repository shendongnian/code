    protected virtual void OnConnectivityChanged(ConnectivityChangedEventArgs e)
    {
        if (ConnectivityChanged != null)
            ConnectivityChanged.Invoke(this, e);
    }
