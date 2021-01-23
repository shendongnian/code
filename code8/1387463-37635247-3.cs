    class Program
    {
        static int NumOfClients = 400;
        static int NumOfMessages = 1000;
        static NetworkStream[] Streams = new NetworkStream[NumOfClients];
        static byte[] Message = new byte[1024];
        static void Main(string[] args)
        {
            Buffer.BlockCopy(BitConverter.GetBytes((short)1024), 0, Message, 0, sizeof(short));
            Console.WriteLine("Press ENTER to run setup");
            Console.ReadLine();
            Setup().Wait();
            Console.WriteLine("Press ENTER to start sending");
            Console.ReadLine();
            NetworkStream sender = Streams[0];
            for (int i = 0; i < NumOfMessages; i++)
            {
                sender.WriteAsync(Message, 0, 1024);
            }
            Console.ReadLine();
        }
        static async Task Setup()
        {
            for (int i = 0; i < Streams.Length; i++)
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect("localhost", 4000);
                NetworkStream stream = tcpClient.GetStream();
                Streams[i] = stream;
                Task.Run(() => CallbackListener(stream));
            }
        }
        static int counter = 0;
        static object objLock = new object();
        static async Task CallbackListener(NetworkStream stream)
        {
            var readBuffer = new byte[1024];
            int totalAmountRead;
            short totalLength;
            while (true)
            {
                totalAmountRead = 0;
                while (totalAmountRead < 2)
                {
                    totalAmountRead += await stream.ReadAsync(readBuffer, totalAmountRead, 2 - totalAmountRead).ConfigureAwait(false);
                }
                totalLength = BitConverter.ToInt16(readBuffer, 0);
                while (totalAmountRead < totalLength)
                {
                    totalAmountRead += await stream.ReadAsync(readBuffer, totalAmountRead, totalLength - totalAmountRead).ConfigureAwait(false);
                }
                lock(objLock)
                {
                    counter++;
                    if (counter % 1000 == 0)
                    {
                        // to see progress
                        Console.WriteLine(counter);
                    }
                }
                // do nothing
            }
        }
    }
