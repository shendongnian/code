    bool Connection = checkNetworkConnection()
    if(Connection == false)
    { 
         // Here is ConnectionSettingTask to Go directly InternetSetting 
         ConnectionSettingsTask cst = new ConnectionSettingsTask();
         cst.ConnectionSettingsType = ConnectionSettingsType.Cellular;
         cst.Show(); 
    }
    public static bool checkNetworkConnection() 
    {
        var ni = NetworkInterface.NetworkInterfaceType;
        bool IsConnected = false;
        if ((ni == NetworkInterfaceType.Wireless80211)|| (ni == NetworkInterfaceType.MobileBroadbandCdma)|| (ni == NetworkInterfaceType.MobileBroadbandGsm))
            IsConnected= true;
        else if (ni == NetworkInterfaceType.None)
             IsConnected= false;
        return IsConnected;
    }
