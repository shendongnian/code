    static void Main(string[] args)
    {
        var chn = new HttpChannel();
        ChannelServices.RegisterChannel(chn, false);
    
        RemotingConfiguration.RegisterWellKnownClientType(
            typeof(Server),
            "http://localhost:1234/server");
    
        Console.WriteLine("Creating server...");
        var s = new Server();
    
        Console.WriteLine("type chars, press p to print, press x to stop");
        var ch = Console.ReadKey();
        while(ch.KeyChar != 'x')
        {
                    
            switch(ch.KeyChar )
            {
                case 'p':
                    Console.WriteLine("msg: {0}", s.GetMessage());
                    break;
                default:
                    Console.WriteLine("Got value {0} ", s.DoWork(ch.KeyChar));
                    break;
            }
                    
                ch = Console.ReadKey();
        }
        Console.WriteLine("stopped");
    }
