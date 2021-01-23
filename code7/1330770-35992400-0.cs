        private int _port;
        private TcpListener _tcpListener;
        private bool _running, _disposed;
        private BinaryFormatter _bFormatter;
        private Thread _connectionThread;
        private BackgroundWorker _bgwListener;
        private BackgroundWorker _bgwSender;
        private object syncobject = new object();
        private object syncsendmessageobject = new object();
        /// <summary>
        /// Constructor - Initialises the TCPServer with the given port and a tcplistener. Starts a thread to monitor the message queue
        /// </summary>
        /// <param name="port"></param>
        public TCPServer(int port)
        {
            try
            {
                this._port = port;
                this._tcpListener = new TcpListener(IPAddress.Loopback, port);
                this._running = false;
                this._bFormatter = new BinaryFormatter();
                Thread thread = new Thread(ReadQueue);
                thread.Start();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Starts the tcplistener.
        /// </summary>
        public void Start()
        {
            try
            {
                if (!_running)
                {
                    this.MessageReceived -= TCPServer_MessageReceived;
                    this._tcpListener.Start();                   
                    this._running = true;
                    this._connectionThread = new Thread(new ThreadStart(ListenForClientConnections));
                    this._connectionThread.Start();
                    this._connectionThread.IsBackground = true;
                    this.MessageReceived += TCPServer_MessageReceived;
                }
            }           
            catch (Exception ex)
            {
            }
        }        
      
        /// <summary>
        /// Stops the tcplistener
        /// </summary>
        public void Stop()
        {
            if (this._running)
            {
                this._tcpListener.Stop();
                this._tcpListener = null;
                this._running = false;
            }
        }
        public bool Running()
        {
            return this._running;
        }
        public void StopListening()
        {
            try
            {
                lock (this)
                {
                    if (this._running)
                    {
                        this._tcpListener.AcceptTcpClient().Close();
                        _running = false;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Thread body for listening for client connections
        /// </summary>
        private void ListenForClientConnections()
        {
            try
            {
                while (this._running)
                {
                    lock (this)
                    {
                        TcpClient connectedTcpClient = this._tcpListener.AcceptTcpClient();
                        this._bgwListener = new BackgroundWorker();
                        this._bgwListener.DoWork += _bgwListener_DoWork;
                        this._bgwListener.WorkerReportsProgress = true;
                        this._bgwListener.ProgressChanged += _bgwListener_ProgressChanged;
                        this._bgwListener.RunWorkerAsync(connectedTcpClient);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
            
        /// <summary>
        /// background worker listens to messages sent by clients. Categorises them based on messages/commands/applicationcommands/
        /// progress response etc..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TcpClient clientGUI = null;
        private Queue<string> messageQueue = new Queue<string>();
        private void _bgwListener_DoWork(object sender, DoWorkEventArgs e)        
        {           
            TcpClient client = e.Argument as TcpClient;
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            if (client != null)
            {
                try
                {
                    while (this._running)
                    {
                        // Block until an instance Message is received 
                       string message = this._bFormatter.Deserialize(client.GetStream()).ToString();
                        if (message.Equals("GUI", StringComparison.InvariantCultureIgnoreCase)
                        {
                            // Chek for first message from tcp client, if it is GUI then store it in a member variable, if you have multiple cleints then use a dictionary
                            clientGUI = client;
                        }
                        if(!clientGUI.Equals(client))
                        {
                            lock (syncobject)
                            {                   
                                messageQueue.Enqueue(message);                 
                            }
                        }                       
                     
                    }
                }
                catch (Exception ex)
                {
                }
               
            }
        }
        /// <summary>
        /// Thread that continuously monitors the message queue for messages and 
        /// sends them to clients
        /// </summary>
        private void ReadQueue()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        TCPMessage message = null;
                      
                        if (messageQueue.Count > 0)
                        {                          
                            lock (syncobject)
                            {
                                message = messageQueue.Dequeue();                               
                            }
                           
                            if (!string.IsNullOrEmpty(message) && clientGUI != null)
                            {
                                SendMessage(clientGUI, message);
                            }
                          
                        }
                        else { Thread.Sleep(10); }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                
            }           
        }
      
        private MessageReceivedEventHandler _messageReceived;
        public event MessageReceivedEventHandler MessageReceived
        {
            add { _messageReceived += value; }
            remove { _messageReceived -= value; }
        }
        private EventHandler<MessageEventArgs> _serverMessageSent;
        public event EventHandler<MessageEventArgs> ServerMessageSent
        {
            add { _serverMessageSent += value; }
            remove { _serverMessageSent -= value; }
        }
  
        private void SendMessage(TcpClient client, TCPMessage message)
        {
            try
            {
                lock (syncsendmessageobject)
                    _bFormatter.Serialize(client.GetStream(), message);
            }
            catch (Exception ex)
            {
            }
        }       
    }    
