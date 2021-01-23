    foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    Console.Writeline(netInterface.NetworkInterfaceType.ToString()
                }
            }
