    class Program
        {
            static void Main(string[] args)
            {
                TcpListener server = null;
                try
                {
                    Int32 port = 3000;
                   // IPAddress localAddr = IPAddress.Parse(IPAddress.Any);
    
                    server = new TcpListener(IPAddress.Any, port);
    
                    server.Start();
    
                    // Buffer for reading data
                    Byte[] bytes = new Byte[256];
                    String data = null;
    
                    while (true)
                    {
                        Console.Write("Waiting for a connection... ");
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected!");
                        
                        
                        data = null;
    
                        NetworkStream stream = client.GetStream();
    
                        byte[] aaa = { 0, 1, 0, 2, 0, 11, 3, 0, 1, 0, 4, 195, 128 };
                        stream.Write(aaa, 0, aaa.Length);
                        int i;
    
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
    
                            data = data.ToUpper();
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                        }
    
                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    server.Stop();
                }
    
    
                Console.WriteLine("\nHit enter to continue...");
                Console.Read();
            }
        }
