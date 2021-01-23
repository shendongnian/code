    protected override async void OnLoad(EventArgs e)
    {
        while (true)
        {
            pSvr = await PingServer(ioIP, int.Parse(ioPort));
            if (pSvr == true)
            {
                label3.Text = "Connected to server. Please wait...";
                tmr.Interval = 15000; 
                tmr.Tick += timerHandler;
                tmr.Start();
                break;
            }
            await Task.Delay(5000);
        }
    }
    async Task<bool> PingServer(string _HostIP, int _PortNumber)
    {
        try
        {
            TcpClient client = new TcpClient();
            await client.ConnectAsync(_HostIP, _PortNumber);
            Console.WriteLine("Server successfully connected...");
            return true;
        }
        catch
        {
            Console.WriteLine("Error pinging server...");
            return false;
        }
    }
