    class Listener
    {
        private Socket _socket;
        public bool Listening { get; private set; }
        public int Port { get; private set; }
        public Listener(int port)
        {
            Port = port;
            _socket=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start()
        {
            if (Listening)
            {
                return;
            }
            _socket.Bind(new IPEndPoint(0,Port));
            _socket.Listen(0);
            _socket.BeginAccept(callback, null);
            Listening = true;
        }
        public void Stop()
        {
            if (!Listening)
            {
                return;
            }
            _socket.Close();
            _socket.Dispose();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        void callback(IAsyncResult ar)
        {
            try
            {
                Socket socket = this._socket.EndAccept(ar);
                if (SocketAccepted!=null)
                {
                    SocketAccepted(socket);
                }
                this._socket.BeginAccept(callback, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
    class Client
    {
        public string ID { get; private set; }
        public IPEndPoint EndPoint { get; private set; }
        private Socket sck;
        public Client(Socket accepted)
        {
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] {0}, 0, 0, 0, callback, null);
        }
        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);
                byte[] buf=new byte[8192];
                int rec = sck.Receive(buf, buf.Length, 0);
                if (rec<buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }
                if (Received!=null)
                {
                    Received(this, buf);
                }
                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                sck.Close();
                if (Disconnected!=null)
                {
                    Disconnected(this);
                }
            }
            
        }
        
        public void Close()
        {
            sck.Close();
            sck.Dispose();
        }
        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDiscconnectedHandler(Client sender);
        public event ClientReceivedHandler Received;
        public event ClientDiscconnectedHandler Disconnected;
    }
    
