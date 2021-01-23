    static void Main(string[] args)
        {
            string messageFromClient = null;
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] bytes = new byte[1024];
            IPAddress ipAdress = IPAddress.Parse(LocalIPAddress());
            const int PORT = 13000;
            IPEndPoint localEndPoint = new IPEndPoint(ipAdress, PORT);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                Console.WriteLine("Wating for a connection..");
                Socket handler = listener.Accept();
                Console.WriteLine("Got a connection from {0}", handler.RemoteEndPoint.ToString());
                while (true)
                {
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        messageFromClient += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (messageFromClient.IndexOf("<Stop>") > -1) break;
                    }
                    if (messageFromClient.Contains("<EOG>"))
                    {
                        Console.WriteLine("Text recived: {0}", messageFromClient.Replace("<Stop>", ""));
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        Console.WriteLine("Handler closed.");
                        return;
                    }
                    Console.WriteLine("Text recived: {0}", messageFromClient.Replace("<Stop>", ""));
                    messageFromClient = null;
                    string readInput = Console.ReadLine() + "<Stop>";
                    byte[] messageToClient = Encoding.ASCII.GetBytes(readInput);
                    handler.Send(messageToClient);
                    if (readInput.Contains("<EOG>"))
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        Console.WriteLine("Handler closed.");
                        return;
                    }
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ToString());
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.ToString());
            }
        }
        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
