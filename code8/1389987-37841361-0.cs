         CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                  
                    if (args.IsConnected.ToString().Equals("False"))
                    {
                        if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                        {
                            // WE LOST AN CONNECTION BUT WIFI IS STILL ON 
                        }
                    }
                    else
                    {
                        if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                        {
                            // WIFI WAS TURN ON AND WE HAVE A CONNECTION 
                        }
                        else
                        {
                            // WE HAVE A CONNECTION BUT NOT WIFI
                        }
                    }
                };
