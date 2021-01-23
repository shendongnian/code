     delegate void AddTextCallback(string text);
            public Form1()
            {
                InitializeComponent();
            }
            private void ButtonConnected_Click(object sender, EventArgs e)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ServerHandler));
            }
    
            private void ServerHandler(object state)
            {
                TcpListener _listner = new TcpListener(IPAddress.Parse("12.2.54.658"), 145);
    
                _listner.Start();
    
                AddText("Server started - Listening on port 145");
    
                Socket _sock = _listner.AcceptSocket();
    
                //AddText("User from IP " + _sock.RemoteEndPoint);
    
                while (_sock.Connected)
                {
                    byte[] _Buffer = new byte[1024];
    
                    int _DataReceived = _sock.Receive(_Buffer);
    
                    if (_DataReceived == 0)
                    {
                        break;
                    }
    
                    AddText("Message Received...");
    
                    string _Message = Encoding.ASCII.GetString(_Buffer);
    
                    AddText(_Message);
                }
    
                _sock.Close();
                AddText("Client Disconnected.");
    
                _listner.Stop();
                AddText("Server Stop.");
            }
    
            private void AddText(string text)
            {
                if (this.listBox1.InvokeRequired)
                {
                    AddTextCallback d = new AddTextCallback(AddText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.listBox1.Items.Add(text);
                }
            }
