             try
             {
                byte[] data = new byte[1024];
                string stringData;
    
                TcpClient tcpClient = new TcpClient("127.0.0.1", 1234);
                NetworkStream ns = tcpClient.GetStream();             
    
                var serializer = new XmlSerializer(typeof(string[]));
                var stringArr = (string[])serializer.Deserialize(tcpClient.GetStream());
    
                foreach (string s in stringArr)
                {
                    Console.WriteLine(s);
                }
    
                string input = Console.ReadLine();
                ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns.Flush();
    
    
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
    
            Console.Read();
