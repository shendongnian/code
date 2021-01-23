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
            public static void Main(string[] args)
            {
                TcpListener server = null;
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
                    while (true)
                    {
                        Thread.Sleep(10);
                        // Create a TCP socket.
                        TcpClient tcpClient = server.AcceptTcpClient();
                        // Read the data stream from the client.
                        NetworkStream stream = tcpClient.GetStream();
                        byte[] buffer = new byte[256];
                        Console.WriteLine("Start receiving content");
    
                        int read = stream.Read(buffer, 0, buffer.Length);
                        MemoryStream saved = new MemoryStream();
                        saved.Write(buffer, 0, read);
                        while (read > 0)
                        {
                            read = stream.Read(buffer, 0, buffer.Length);
                            saved.Write(buffer, 0, read);
    
                            //Check if the last four bytes were a double \r\n.
                            var aBytes = saved.ToArray();
                            int len = aBytes.Length;
                            if (aBytes.Length >= 4 && aBytes[len - 1] == '\n' && aBytes[len - 2] == '\r' && aBytes[len - 3] == '\n' && aBytes[len - 4] == '\r')
                                break;
                        }
                        Console.WriteLine("End of receive.");
                        string originalRequest = Encoding.ASCII.GetString(saved.ToArray());
                        byte[] origBytes = saved.ToArray();
                        Console.WriteLine(originalRequest);
                        //Find the hoster and do our own request.
                        string host = originalRequest.Split(new char[] { '\n'}).First(line => line.StartsWith("Host:"));
                        host = host.Substring(5).Trim(); //Cut of rest.
                        Console.WriteLine("The host is: " + host);
                        //Do our own request.
                        try {
                            Socket sProxy = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            sProxy.Connect(host, 80);
                            sProxy.Send(origBytes);
                            //Now route everything between the tcpclient and this socket...
    
                            //create the state object
                            var state = new ProxyState() { ourSocket = sProxy, incomingClient = stream };
                            sProxy.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(Receiver), state);
    
                            stream.BeginRead(buffSend, 0, buffSend.Length, new AsyncCallback(SendToHTTPServer), state);
                        }
                        catch (Exception) { Console.WriteLine("Exception while doing our own request"); }
                    }
                }
                catch (Exception) { Console.WriteLine("Setting up the server failed"); }
            }
    
            private static void SendToHTTPServer(IAsyncResult ar)
            {
                ProxyState back = (ProxyState)ar.AsyncState;
                int rec = back.incomingClient.EndRead(ar);
                //Push this content to the server
                back.ourSocket.Send(buffSend.Take(rec).ToArray());
                back.incomingClient.BeginRead(buffSend, 0, buffSend.Length, new AsyncCallback(SendToHTTPServer), back);
            }
    
            static void Receiver(IAsyncResult state)
            {
                //Console.WriteLine("Got into func");
                ProxyState back = (ProxyState)state.AsyncState;
                int rec = back.ourSocket.EndReceive(state);
                //Console.WriteLine("Received from our socket: " + ASCIIEncoding.ASCII.GetString(buffReceive,0, rec));
                back.incomingClient.Write(buffReceive, 0, rec);
    
                back.ourSocket.BeginReceive(buffReceive, 0, buffReceive.Length, SocketFlags.None, new AsyncCallback(Receiver), back);
            }
    
            private static byte[] buffReceive = new byte[1024];
            private static byte[] buffSend = new byte[1024];
    
            class ProxyState
            {
                public NetworkStream incomingClient { get; set; }
                public Socket ourSocket { get; set; }
            }
        }
    }
