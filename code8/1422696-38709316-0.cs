    class TcpHelper
    {
        class ClientData : IDisposable
        {
            private static int _nextId;
            public int ID { get; private set; }
            public TcpClient Client { get; private set; }
            public TextReader Reader { get; private set; }
            public TextWriter Writer { get; private set; }
            public ClientData(TcpClient client)
            {
                ID = _nextId++;
                Client = client;
                NetworkStream stream = client.GetStream();
                Reader = new StreamReader(stream);
                Writer = new StreamWriter(stream);
            }
            public void Dispose()
            {
                Writer.Close();
                Reader.Close();
                Client.Close();
            }
        }
        private static readonly object _lock = new object();
        private static readonly List<ClientData> _connections = new List<ClientData>();
        private static TcpListener listener { get; set; }
        private static bool accept { get; set; }
        public static async Task StartListener()
        {
            IPAddress address = IPAddress.Any;
            int port = 5678;
            listener = new TcpListener(address, port);
            listener.Start();
            Console.WriteLine("Server started. Listening to TCP clients on port {0}", port);
            while (true)
            {
                var tcpClient = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client has connected");
                var task = StartHandleConnectionAsync(tcpClient);
                if (task.IsFaulted)
                    task.Wait();
            }
        }
        // Register and handle the connection
        private static async Task StartHandleConnectionAsync(TcpClient tcpClient)
        {
            ClientData clientData = new ClientData(tcpClient);
            lock (_lock) _connections.Add(clientData);
            // catch all errors of HandleConnectionAsync
            try
            {
                await HandleConnectionAsync(clientData);
            }
            catch (Exception ex)
            {
                // log the error
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                lock (_lock) _connections.Remove(clientData);
                clientData.Dispose();
            }
        }
        private static async Task HandleConnectionAsync(ClientData clientData)
        {
            Console.WriteLine("Client connected. Waiting for data.");
            string clientmessage;
            while ((clientmessage = await clientData.Reader.ReadLineAsync()) != null && clientmessage != "quit")
            {
                string message = "From " + clientData.ID + ": " + clientmessage;
                Console.WriteLine(message);
                IEnumerable<ClientData> recipients;
                lock (_lock) recipients = _connections.Where(r => r.ID != clientData.ID).ToList();
                foreach (ClientData recipient in recipients)
                {
                    recipient.Writer.WriteLine(message);
                    recipient.Writer.Flush();
                }
            }
            Console.WriteLine("Closing connection.");
        }
    }
