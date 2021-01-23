    class Program
    {
        private const int _kport = 5678;
        private static async Task clientConnect()
        {
            IPAddress address = IPAddress.Loopback;
            TcpClient socketForServer = new TcpClient();
            string userName;
            Console.Write("Input Username: ");
            userName = Console.ReadLine();
            try
            {
                await socketForServer.ConnectAsync(address, _kport);
                Console.WriteLine("Connected to Server");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Connect to server {0}:{1}", address, _kport);
                return;
            }
            using (NetworkStream networkStream = socketForServer.GetStream())
            {
                var readTask = ((Func<Task>)(async () =>
                {
                    using (StreamReader reader = new StreamReader(networkStream))
                    {
                        string receivedText;
                        while ((receivedText = await reader.ReadLineAsync()) != null)
                        {
                            Console.WriteLine("Server:" + receivedText);
                        }
                    }
                }))();
                using (StreamWriter streamwriter = new StreamWriter(networkStream))
                {
                    try
                    {
                        while (true)
                        {
                            Console.Write(userName + ": ");
                            string clientmessage = Console.ReadLine();
                            if ((clientmessage == "quit") || (clientmessage == "QUIT"))
                            {
                                streamwriter.WriteLine(userName + " has left the conversation");
                                streamwriter.WriteLine("quit");
                                streamwriter.Flush();
                                break;
                            }
                            else
                            {
                                streamwriter.WriteLine(userName + ": " + clientmessage);
                                streamwriter.Flush();
                            }
                        }
                        await readTask;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception writing to server: " + e);
                        throw;
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            clientConnect().Wait();
        }
    }
