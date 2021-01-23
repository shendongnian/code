    public class Program
    {
        public static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8989);
            server.Start();
            server.BeginAcceptSocket(AcceptSocket, server);
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 8989);
            FileStream dataToSend = File.OpenRead("c:\\temp\\videoUpload.rar");
            byte[] tempSendBuffer = new byte[4096];
            int numberOfBytesRead = 0;
            while ((numberOfBytesRead = dataToSend.Read(tempSendBuffer, 0, tempSendBuffer.Length)) > 0)
            {
                client.GetStream().Write(tempSendBuffer, 0, numberOfBytesRead);
                Console.WriteLine("{0} bytes sent", numberOfBytesRead);
            }
            Console.ReadLine();
        }
        private static void AcceptSocket(IAsyncResult asyncResult)
        {
            Socket localSocket = (asyncResult.AsyncState as TcpListener).EndAcceptSocket(asyncResult);
            while (true)
            {
                if (localSocket.Available > 0)
                {
                    Console.WriteLine("Local Socket has {0} bytes pending to be received. Enter to receive", localSocket.Available);
                    Console.ReadLine();
                    byte[] tempReadBuffer = new byte[4096];
                    int numberOfReceivedBytes = localSocket.Receive(tempReadBuffer);
                    Console.WriteLine("{0} bytes RECEIVED", numberOfReceivedBytes);
                }
                Thread.Sleep(500);
            }
        }
    }
