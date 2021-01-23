      NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(adapter.Name);
                Console.WriteLine(adapter.NetworkInterfaceType);
                Console.WriteLine(adapter.ID);
            }
            Console.WriteLine();
