    public sealed partial class MainPage : Page
    {
        private StreamSocketListener _listener;
        private StreamSocket _client;
        private StreamSocket _socket;
        private HostName _host;
        private int _port = 54321;
    
        public MainPage()
        {
            InitializeComponent();
            _listener = new StreamSocketListener();
            _listener.ConnectionReceived += async (sender, args) =>
            {
                _socket = args.Socket;
                await Receive();
            };
            _host = NetworkInformation.GetHostNames().FirstOrDefault(x => x.IPInformation != null && x.Type == HostNameType.Ipv4);
        }
    
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await _listener.BindEndpointAsync(_host, $"{_port}");
            await Task.Run(async () =>
            {
                _client = new StreamSocket();
                await _client.ConnectAsync(_host, $"{_port}");
    
                int command = 1;
                byte[] cmd = BitConverter.GetBytes(command);
                byte[] path = Encoding.UTF8.GetBytes(@"C:\Users\Dave\Music\Offaiah-Trouble_(Club_Mix).mp3");
                byte[] length = BitConverter.GetBytes(path.Length);
                byte[] result = cmd.Concat(length.Concat(path)).ToArray();
                await _client.OutputStream.WriteAsync(result.AsBuffer());
            });
        }
    
        private async Task Receive()
        {
            while (true)
            {
                IBuffer inbuffer = new Windows.Storage.Streams.Buffer(4);
                await _socket.InputStream.ReadAsync(inbuffer, 4, InputStreamOptions.None);
                int command = BitConverter.ToInt32(inbuffer.ToArray(), 0);
                //The inbuffer at this point contains: "\u0001\0\0\0", and the BitConverter resolves this to 1
    
                inbuffer = new Windows.Storage.Streams.Buffer(4);
                await _socket.InputStream.ReadAsync(inbuffer, 4, InputStreamOptions.None);
                int length = BitConverter.ToInt32(inbuffer.ToArray(), 0);
                //The inbuffer now contains: "2\0\0\0", and the BitConverter resolves this to "50"
    
                inbuffer = new Windows.Storage.Streams.Buffer((uint)length);
                await _socket.InputStream.ReadAsync(inbuffer, (uint)length, InputStreamOptions.Partial);
                string path = Encoding.UTF8.GetString(inbuffer.ToArray());
            }
        }
    }
