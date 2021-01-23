    IPAddress localAddr = null;
    try
    {
        using (UdpClient udpClient = new UdpClient("8.8.8.8", 0)) //connect to google dns
        {
            localAddr = ((IPEndPoint)udpClient.Client.LocalEndPoint).Address;
            udpClient.Client.Close();
            udpClient.Close();
        }
    }
    catch (SocketException sex)
    {
        Console.WriteLine("Failed to make UDP connection, no connection to DNS ? ");
    }
    //find all network interfaces
    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    NetworkInterface activeAdapter = null;
    foreach (NetworkInterface adapter in nics.Where(n => n.OperationalStatus == OperationalStatus.Up))
    {
        //wifi adapter will be 'up' only if its associated with a hotspot
        IPInterfaceProperties properties = adapter.GetIPProperties();
        var match = properties.UnicastAddresses.Any(a => a.Address.Equals(localAddr));
        if (match)
        {
            activeAdapter = adapter;
            break;
        }
    }
