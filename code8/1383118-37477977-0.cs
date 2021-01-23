    public static Task<List<IPAddress>> ScanAsync(List<IPAddress> addresses, ushort port)
    {
        int count = addresses.Count;
        Task[] tasks = new Task[count];
        //Loop through ip address
        for(int x = 0; x <= count -1; x++)
        {
            tasks.Add(CheckIpAsync(addresses[x], port));
        }
        await Task.WhenAll(tasks);
        return openSystems;
    }
    private async Task CheckIpAsync(string address, int port)
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
