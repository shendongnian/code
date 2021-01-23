        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.Resolve("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 2012);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            List<string> list = new List<string>
                {
                    "Test1\r\n",
                    "Test2",
                    "Test3\r\n",
                    "Test4\r\n",
                    "Test5\r\n",
                    "Test6\r\n",
                    "Test7",
                    "Test8\r\n",
                    "Test9\r\n",
                };
            foreach (string s in list)
                sender.Send(Encoding.ASCII.GetBytes(s));
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
