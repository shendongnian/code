    public class MyServer : IPCameraServer
        {
            private MediaConnector _connector;
            private IIPCamera _camera;
            private IIPCameraClient _client;
    
            public string IpAddress { get; set; }
            public int Port { get; set; }
    
            public event EventHandler ClientCountChange;
    
            public MyServer()
            {
                _connector = new MediaConnector();
                _camera = IPCameraFactory.GetCamera("192.168.115.98:8080", "admin", "admin");
    
                if (_camera != null)
                    _camera.Start();
            }
    
            protected override void OnClientConnected(IIPCameraClient client)
            {
                _client = client;
                _connector.Connect(_camera.AudioChannel, _client.AudioChannel);
                _connector.Connect(_camera.VideoChannel, _client.VideoChannel);
    
                var handler = ClientCountChange;
                if (handler != null)
                    handler(null, new EventArgs());
    
                base.OnClientConnected(_client);
            }
    
            protected override void OnClientDisconnected(IIPCameraClient client)
            {
                _connector.Disconnect(_camera.AudioChannel, _client.AudioChannel);
                _connector.Disconnect(_camera.VideoChannel, _client.VideoChannel);
                _connector.Dispose();
    
                var handler = ClientCountChange;
                if (handler != null)
                    handler(null, new EventArgs());
    
                base.OnClientDisconnected(client);
            }
        }
    
        class Program
        {
            static MyServer _server = new MyServer();
    
            static void Main(string[] args)
            {
                _server.Start();
                _server.SetListenAddress("192.168.115.10", 554);
                _server.ClientCountChange += new EventHandler(server_ClientCountChange);
                Console.WriteLine("Started");
                Console.Read();
            }
    
            static void server_ClientCountChange(object sender, EventArgs e)
            {
                _server.ConnectedClients.ForEach(x => Console.WriteLine(x.TransportInfo.RemoteEndPoint.ToString()));
            }
        }
