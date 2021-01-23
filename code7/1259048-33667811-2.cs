            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"),22001);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                using (StreamReader reader = new StreamReader(client.GetStream()))
                {
                    while (reader.Read()>0)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
