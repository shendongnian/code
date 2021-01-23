    public class WSDiscoveryClient
    {
        public class WSEndpoint
        {
            public string ID;
            public string URL;
        }
    
        private List<WSEndpoint> _endPoints;
        private int port = 30000;
        private int timeOut = 5; // seconds
    
        /// <summary>
        /// Get available Webservices
        /// </summary>
        public async Task<List<WSEndpoint>> GetAvailableWSEndpoints()
        {
            _endPoints = new List<WSEndpoint>();
    
            using (var socket = new DatagramSocket())
            {
                // Set the callback for servers' responses
                socket.MessageReceived += SocketOnMessageReceived;
                // Start listening for servers' responses
                await socket.BindServiceNameAsync(port.ToString());
    
                // Send a search message
                await SendMessage(socket);
                // Waits the timeout in order to receive all the servers' responses
                await Task.Delay(TimeSpan.FromSeconds(timeOut));
            }
            return _endPoints;
        }
    
        /// <summary>
        /// Sends a broadcast message searching for available Webservices
        /// </summary>
        private async Task SendMessage(DatagramSocket socket)
        {
            using (var stream = await socket.GetOutputStreamAsync(new HostName("255.255.255.255"), port.ToString()))
            {
                using (var writer = new DataWriter(stream))
                {
                    var data = Encoding.UTF8.GetBytes("SEARCHWS");
                    writer.WriteBytes(data);
                    await writer.StoreAsync();
                }
            }
        }
    
        private async void SocketOnMessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            // Creates a reader for the incoming message
            var resultStream = args.GetDataStream().AsStreamForRead(1024);
            using (var reader = new StreamReader(resultStream))
            {
                // Get the message received
                string message = await reader.ReadToEndAsync();
                // Cheks if the message is a response from a server
                if (message.StartsWith("WSRESPONSE", StringComparison.CurrentCultureIgnoreCase))
                {
                    // Spected format: WSRESPONSE;<ID>;<HTTP ADDRESS>
                    var splitedMessage = message.Split(';');
                    if (splitedMessage.Length == 3)
                    {
                        var id = splitedMessage[1];
                        var url = splitedMessage[2];
                        _endPoints.Add(new WSEndpoint() { ID = id, URL = url });
                    }
                }
            }
        }
    }
