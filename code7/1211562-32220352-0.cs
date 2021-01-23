             try
            {
                TcpClient client = new TcpClient();
                client.Connect("Your Host", 1433);
                Console.WriteLine("Connection open");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection not open");
            }
