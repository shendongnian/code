    static void Main(string[] args)
    {
        // which port 
        var chn = new HttpChannel(1234);
        ChannelServices.RegisterChannel(chn, false);
    
        // Create only ONE Server instance
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Server), "server", WellKnownObjectMode.Singleton);
    
        Server.Value = 0;
        while (!Console.KeyAvailable)
        {
            Server.Value++;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(Server.Value);
        }
    }
