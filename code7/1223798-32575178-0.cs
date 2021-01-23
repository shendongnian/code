            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces)
                {
                    if (Interface.OperationalStatus == OperationalStatus.Up)
                    {
                        if ((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) && (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {
                            IPv4InterfaceStatistics statistics = Interface.GetIPv4Statistics();
                            MessageBox.Show(Interface.Name + " " + Interface.NetworkInterfaceType.ToString() + " " + Interface.Description);
                        }
                        else
                        {
                            MessageBox.Show("VPN Connection is lost!");
                        }
                    }
                }
            }    
