    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 1234);
            tcpListener.Start();
            while (true)
            {
                using (TcpClient tcpClient = tcpListener.AcceptTcpClient())
                {
                    using (var network_stream = tcpClient.GetStream())
                    {
                        using (BinaryReader reader = new BinaryReader(network_stream))
                        {
                            using (BinaryWriter writer = new BinaryWriter(network_stream))
                            {
                                string[] arr1 = new string[] { "one", "two", "three" };
                                writer.Write(arr1.Length);
                                foreach (var item in arr1)
                                {
                                    writer.Write(item);
                                }
                                var id = reader.ReadString();
                                Console.WriteLine("Id: " + id);
                            }
                        }
                    }
                
                }
            }
        }
    }
