    TcpListener tcpListener = new TcpListener(IPAddress.Any, 1234);
            tcpListener.Start();  
            while (true)
            {                     
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                byte[] data = new byte[1024];
                NetworkStream ns = tcpClient.GetStream();
                string[] arr1 = new string[] { "one", "two", "three" };
                var serializer = new XmlSerializer(typeof(string[]));
                serializer.Serialize(tcpClient.GetStream(), arr1);
                tcpClient.GetStream().Close()
                tcpClient.Close();
    
                  int recv = ns.Read(data, 0, data.Length);
                   in this line
    
                string id = Encoding.ASCII.GetString(data, 0, recv);
    
                Console.WriteLine(id);
    
                }               
            }
