     public void UpdateNetworkInformation()
        {
            // Get current Internet Connection Profile.
            ConnectionProfile internetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
            //air plan mode is on...
            if (internetConnectionProfile == null)
            {
                Is_Connected = false;
                return;
            }
            
            //if true, internet is accessible.
            this.Is_InternetAvailable = internetConnectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            // Check the connection details.
            else if (internetConnectionProfile.NetworkAdapter.IanaInterfaceType != 71)// Connection is not a Wi-Fi connection. 
            {
                Is_Roaming = internetConnectionProfile.GetConnectionCost().Roaming;
                /// user is Low on Data package only send low data.
                Is_LowOnData = internetConnectionProfile.GetConnectionCost().ApproachingDataLimit;
                //User is over limit do not send data
                Is_OverDataLimit = internetConnectionProfile.GetConnectionCost().OverDataLimit;
            }
            else //Connection is a Wi-Fi connection. Data restrictions are not necessary. 
            {
                Is_Wifi_Connected = true;
            }
        }
