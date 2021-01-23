    	private static void StartServers()
	{
		for (int i = Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortStart"));
                        i <= Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortEnd"));
                        i++)
                    {
                        var localAddr = IPAddress.Parse(ConfigurationManager.AppSettings.Get("IpAddress"));
                        var server = new TcpListener(localAddr, i);
                        Servers.Add(server);
                        server.Start();
                        StartAccept(server);
                    }
	}
    private static void StartAccept(TcpListener server)
        {
            server.BeginAcceptTcpClient(OnAccept, server);
        }
    private static void OnAccept(IAsyncResult res)
        {
            var client = new TcpClient();
            try
            {
                Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.Red
                    ? ConsoleColor.Green
                    : ConsoleColor.White;
                var server = (TcpListener) res.AsyncState;
                StartAccept(server);
                client = server.EndAcceptTcpClient(res);
                Console.WriteLine("Connected!\n");
                var bytes = new byte[512];
                // Get a stream object for reading and writing
                var stream = client.GetStream();
                int i;
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    var data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0} \n", data);
                    // Process the data sent by the client.
                    data = InterpretMessage(data);
                    var msg = Encoding.ASCII.GetBytes(data);
                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0} \n", data);
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                client.Close();
                Console.WriteLine(exception.Message);
            }
        }
    
