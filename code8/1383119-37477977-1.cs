    public static Task<List<IPAddress>> ScanAsync(List<IPAddress> addresses, ushort port)
    {
        var tasks = addresses.Select(a => CheckIpAsync(a, port);
        
        await Task.WhenAll(tasks);
        return openSystems;
    }
    private async Task CheckIpAsync(IPAddress address, ushort port)
    {
        using (TcpClient tcp = new TcpClient())
        {
            try
            {
                Console.WriteLine("Trying to get into {0}", address);
                await tcp.ConnectAsync(address, port);
                openSystems.Add(address);
            }
            catch
            {
                Console.WriteLine("Can't get into {0}", address);
                //ignore exceptions
            }
        }
    }
