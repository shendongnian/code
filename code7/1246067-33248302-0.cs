    var client = Dns.GetHostEntry(Dns.GetHostName());
    foreach (var ip in client.AddressList)
    {
        if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            ipAddress = ip;
        }
    }
