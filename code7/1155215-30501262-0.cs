    Dictionary<string, int> ips = new Dictionary<string, int>();
    // ...
    foreach (TcpConnectionInformation info in tcpConnections)
        {
            string list = info.LocalEndPoint.Address.ToString() + ":" + info.LocalEndPoint.Port.ToString();
            string remote = info.RemoteEndPoint.Address.ToString() + ":" + info.RemoteEndPoint.Port.ToString();
            if (list == serverMonitor)
            {
                if (ips.ContainsKey(remote))
                    ips[remote]++;
                else 
                    ips.Add(remote, 1);
            }
        }
    }          
    foreach(var entry in ips)
    {
        Console.WriteLine("{0} ({1})", entry.Key, entry.Value);
    }
