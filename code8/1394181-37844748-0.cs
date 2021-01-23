    private void CreateListener()
       {
       _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
       _tcpSocket.Bind(new IPEndPoint(IPAddress.Parse("172.16.192.40"), 7000));
       _tcpSocket.Listen(100);
        }
    private void Start()
       {
       if (_tcpSocket == null)
          {
          CreateListener();
          }
       WaitForClientConnection();
       //waits till client connect
       StartReceive();
       }
    private void WaitForClientConnection()
       {            
        _tcpClientAcceptSocket = _tcpSocket.Accept();           
       }
