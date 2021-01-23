    bool IsWiredInternetAccess()
        {
    IReadOnlyList<ConnectionProfile> connections = NetworkInformation.GetConnectionProfiles();
        
            foreach (var connection in connections)
         {
                if (connection == null) continue;
                if (connection.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
           // check is connection wired
           if ((connection.ConnectionProfile.IsWlanConnectionProfile)||(connection.IsWwanConnectionProfile))
              {
               // connection is Wlan or Wwan
               return false;
              }
           else
              {
               return true;
              }
            }       
         }
        }
