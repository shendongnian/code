            using (TcpClient client = new TcpClient("127.0.0.1",22001))
            {
                using (StreamWriter writer = new StreamWriter(client.GetStream()))
                {
                    writer.WriteLine("string to write");
                }
            }
