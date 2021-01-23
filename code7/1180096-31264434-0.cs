    ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
    if (internetConnectionProfile.IsWlanConnectionProfile )
    {
         if ( internetConnectionProfile.GetNetworkConnectivityLevel() ==
                    NetworkConnectivityLevel.InternetAccess)
         {
              status= "WiFi Status: On and Connected!";
         }
         else
         {
              status = "WiFi Status: On but not connected!";
         }
    }
    else
    {
        status = "Wifi is Off";
    }
