    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient("127.0.0.1", 1234))
                {
                    using (NetworkStream network_stream = tcpClient.GetStream())
                    {
                        using (BinaryReader reader = new BinaryReader(network_stream))
                        {
                            using (BinaryWriter writer = new BinaryWriter(network_stream))
                            {
                                int number_of_strings = reader.ReadInt32();
                                string[] lines = new string[number_of_strings];
                                for(int i = 0 ; i <  number_of_strings ; i++)
                                {
                                    lines[i] = reader.ReadString(); //Store the strings if you want to
                                    Console.WriteLine(lines[i]);
                                }
                                Console.WriteLine("Please input id:");
                                string id = Console.ReadLine();
                                writer.Write(id);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Console.Read();
        }
    }
