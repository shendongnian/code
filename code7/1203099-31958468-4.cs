    public void EchoNetworkInformation()
    {
       System.Net.NetworkInformation.NetworkInterface[] nics;
       nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
           foreach (var nic in nics)
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 && nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
                    continue;
                   
               Console.WriteLine("Adapter name: " + nic.Name);
               Console.WriteLine("Link speed: " + nic.Speed);
               Console.WriteLine("State: " + nic.OperationalStatus);
               var utilization = GetNetworkUtilization(nic.Description);
               Console.WriteLine("Network utilization", utilization);
                       
            }
    }
