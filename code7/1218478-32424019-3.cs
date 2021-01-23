    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.Threading;
    using System.Text;
    
    namespace SharpProxy
    {
        class MainClass
        {
            private static void StartAcceptingClient(IAsyncResult ar)
            {
                var tcpClient = server.EndAcceptTcpClient(ar);
                server.BeginAcceptTcpClient(new AsyncCallback(StartAcceptingClient), null);
    
                // Read the data stream from the client.
                NetworkStream stream = tcpClient.GetStream();
                byte[] buffer = new byte[256];
                Console.WriteLine("====== GOT A NEW TCP CLIENT ====== " + tcpClient.Client.RemoteEndPoint.ToString());
    
                int read = stream.Read(buffer, 0, 1);
                MemoryStream saved = new MemoryStream();
                saved.Write(buffer, 0, read);
                bool isValid = false;
                while (read > 0 )
                {
                    read = stream.Read(buffer, 0, 1);
                    saved.Write(buffer, 0, read);
    
                    //Check if the last four bytes were a double \r\n.
                    var aBytes = saved.ToArray();
                    int len = aBytes.Length;
                    if (aBytes.Length >= 4 && aBytes[len - 1] == '\n' && aBytes[len - 2] == '\r' && aBytes[len - 3] == '\n' && aBytes[len - 4] == '\r')
                    {
                        isValid = true;
                        break;
                    }
                }
                Console.WriteLine("End of receive.");
                string originalRequest = Encoding.ASCII.GetString(saved.ToArray());
                byte[] origBytes = saved.ToArray();
                saved.Close();
                Console.WriteLine(originalRequest);
                if (!isValid)
                {
                    Console.WriteLine("This wasn't a valid request");
                    return;
                }
                //Find the hoster and do our own request.
                string host = originalRequest.Split(new char[] { '\n' }).First(line => line.StartsWith("Host:"));
                host = host.Substring(5).Trim(); //Cut of rest.
                Console.WriteLine("The host is: " + host);
                //Do our own request.
                try
                {
                    Socket sProxy = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sProxy.Connect(host, 80);
                    sProxy.Send(origBytes);
                    //Now route everything between the tcpclient and this socket...
    
                    //create the state object
                    var state = new ProxyState() { ourSocket = sProxy, incomingClient = stream };
                    sProxy.BeginReceive(state.ReceiveBuffer, 0, state.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(Receiver), state);
    
                    stream.BeginRead(state.SendBuffer, 0, state.SendBuffer.Length, new AsyncCallback(SendToHTTPServer), state);
                }
                catch (Exception) { Console.WriteLine("Exception while doing our own request"); }
            }
    
            static TcpListener server = null;
            public static void Main(string[] args)
            {
                try
                {
                    // Set the TcpListener on port 13000.
                    Int32 port = 13000;
                    IPAddress localAddr = IPAddress.Parse("0.0.0.0");
                    // TcpListener server = new TcpListener(port);
                    server = new TcpListener(localAddr, port);
                    // Start listening for client requests.
                    server.Start();
                    Console.WriteLine("Server started on " + server.LocalEndpoint.ToString());
                    server.BeginAcceptTcpClient(new AsyncCallback(StartAcceptingClient), null);
    
                    while (true)
                        Thread.Sleep(10);   
                }
                catch (Exception) { Console.WriteLine("Setting up the server failed"); }
            }
    
            private static void SendToHTTPServer(IAsyncResult ar)
            {
                try
                {
                    ProxyState back = (ProxyState)ar.AsyncState;
                    int rec = back.incomingClient.EndRead(ar);
                    //Push this content to the server
                    back.ourSocket.Send(back.SendBuffer.Take(rec).ToArray());
                    back.incomingClient.BeginRead(back.SendBuffer, 0, back.SendBuffer.Length, new AsyncCallback(SendToHTTPServer), back);
                }
                catch (Exception e) { Console.WriteLine("Exc. when sending to server: " + e.ToString()); }
            }
    
            static void Receiver(IAsyncResult state)
            {
                try
                {    
                    ProxyState back = (ProxyState)state.AsyncState;
                    int rec = back.ourSocket.EndReceive(state);
                    //Set up the back and forth connections
                    back.incomingClient.Write(back.ReceiveBuffer, 0, rec);
                    back.ourSocket.BeginReceive(back.ReceiveBuffer, 0, back.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(Receiver), back);
                }
                catch (Exception e) { Console.WriteLine("Exc. when receiving from client: " + e.ToString()); }
            }
    
    
            //Every proxy connection has an end an and a beginning, plus a 
            //Sending buffer and a receive buffer
            class ProxyState
            {
                public NetworkStream incomingClient { get; set; }
                public Socket ourSocket { get; set; }
                private byte[] buffReceive = new byte[512];
                private byte[] buffSend = new byte[512];
                public byte[] ReceiveBuffer { get { return buffReceive; } set { buffReceive = value; } }
                public byte[] SendBuffer { get { return buffSend; } set { buffSend = value; } }
            }
        }
    }
