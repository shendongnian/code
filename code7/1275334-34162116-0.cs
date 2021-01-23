    protected virtual void OnConnectivityChanged(ConnectivityChangedEventArg e)
    {
       if(ConnectivityChanged != null)
       {
           ConnectivityChanged.Invoke(this,e);
       }
    }
