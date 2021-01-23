    using System.Net;
    using System.Net.Sockets;
    using System.Diagnostics;
    using System.IO;
    
    namespace ClientSocket_System
    {
        class tcpServerTerminal
        {
    
            
    
            private TcpListener tcpListener;
            private Thread listenThread;
            private TcpClient tcpService;
            string msgFromClient;
    
            
    
            public void ServerStart()
            {
                tcpListener = new TcpListener(IPAddress.Any, 5565);
                listenThread = new Thread(new ThreadStart(ListenForClients));
                listenThread.Start();
            }
    
            public void ListenForClients()
            {
                tcpListener.Start();
    
                while (true)
                {
                    //blocks until a client has connected to the server
                    TcpClient client = this.tcpListener.AcceptTcpClient();
    
                    //create a thread to handle communication 
                    //with connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
    
            public void HandleClientComm(object client)
            {
                tcpService = (TcpClient)client;
    
                NetworkStream netStream = tcpService.GetStream();
    
                byte[] message = new byte[4096];
                int bytesRead;
    
                while (true)
                {
                    bytesRead = 0;
    
                    try
                    {
                        //blocks until a client sends a message
                        bytesRead = netStream.Read(message, 0, 4096);
                    }
                    catch
                    {
                        //a socket error has occured
                        break;
                    }
    
                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        break;
                    }
    
                    //message has successfully been received
                    ASCIIEncoding encoder = new ASCIIEncoding();
    
                    msgFromClient = encoder.GetString(message, 0, bytesRead);
    
                    if (msgFromClient == "SwitchComputers")
                    {
                        
                        //RUN CODE HERE TO ACTION PC SLEEP AND MONITOR SLEEP
                        msgFromClient = null;
                    }
                }
            }
    
            public void SocketSend()
            {
                NetworkStream streamToClient = tcpService.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("SwitchComputers");
    
                streamToClient.Write(buffer, 0, buffer.Length);
                streamToClient.Flush();
            }
    
        }
    }
