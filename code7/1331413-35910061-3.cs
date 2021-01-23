    // register for network status change notifications
     networkStatusCallback = new NetworkStatusChangedEventHandler(OnNetworkStatusChange);
     if (!registeredNetworkStatusNotif)
     {
         NetworkInformation.NetworkStatusChanged += networkStatusCallback;
         registeredNetworkStatusNotif = true;
     }
    async void OnNetworkStatusChange(object sender)
    {
        // get the ConnectionProfile that is currently used to connect to the Internet                
        ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
        if (InternetConnectionProfile == null)
        {
            await _cd.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                rootPage.NotifyUser("Not connected to Internet\n", NotifyType.StatusMessage);
            });
        }
        else
        {
            connectionProfileInfo = GetConnectionProfile(InternetConnectionProfile);
            await _cd.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                rootPage.NotifyUser(connectionProfileInfo, NotifyType.StatusMessage);
            });
        }
        internetProfileInfo = "";
    }
