            using (TcpClient client = new TcpClient("localhost",22001))
            {
                using (StreamWriter writer = new StreamWriter(client.GetStream()))
                {
                    writer.WriteLine("string to write");
                }
            }
