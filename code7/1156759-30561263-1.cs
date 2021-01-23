    static void Main(string[] args)
        {
            IPAddress ipAdress = IPAddress.Parse(LocalIPAddress());
            byte[] bytes = new byte[1024];
            const int PORT = 13000;
            IPEndPoint remoteEP = new IPEndPoint(ipAdress, PORT);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string messageFromServer = null;
            try
            {
                sender.Connect(remoteEP);
                Console.WriteLine("Connected to {0}", sender.RemoteEndPoint.ToString());
                while (true)
                {
                    string readInput = Console.ReadLine() + "<Stop>";
                    byte[] messageToServer = Encoding.ASCII.GetBytes(readInput);
                    if (readInput.Contains("<EOG>"))
                    {
                        int bytesSentEnd = sender.Send(messageToServer);
                        Console.WriteLine("Sent {0} bytes to the server", bytesSentEnd);
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        Console.WriteLine("Sender closed.");
                        return;
                    }
                    int bytesSent = sender.Send(messageToServer);
                    Console.WriteLine("Sent {0} bytes to the server", bytesSent);
                    while (true)
                    {
                        int bytesRec = sender.Receive(bytes);
                        messageFromServer += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (messageFromServer.Contains("<EOG>"))
                        {
                            sender.Shutdown(SocketShutdown.Both);
                            sender.Close();
                            Console.WriteLine("Sender closed.");
                            return;
                        }
                        if (messageFromServer.IndexOf("<Stop>") > -1) break;
                    }
                    Console.WriteLine("Message from server: {0}", messageFromServer.Replace("<Stop>", ""));
                    messageFromServer = null;
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine("Sokcet Exception: {0}", se.ToString());
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Argument Null Exception: {0}", ane.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected excetption: {0}", ex.ToString());
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
