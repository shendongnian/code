        static void Main(string[] args)
        {
            var server = new AppServer();
            
            if (!server.Setup(2012) || !server.Start())
            {
                return;
            }
            server.NewSessionConnected += (session) => Console.WriteLine("new connection");
            server.NewRequestReceived += (session, requestInfo) => Console.WriteLine("new request: Key={0}", requestInfo.Key);
            Console.WriteLine("Press ENTER to exit....");
            Console.ReadLine();
        }
