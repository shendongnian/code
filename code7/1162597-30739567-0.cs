    string SSID;
    var icp = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    if (icp != null)
    {
        if (icp.WlanConnectionProfileDetails != null)
        {
            SSID = icp.WlanConnectionProfileDetails.GetConnectedSsid();
        }
    }
    
