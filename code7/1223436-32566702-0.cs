    internal class Program
        {
            public static int Intialise()
            {
                int i = startServer();
                Thread readall = new Thread(readAllMessage);
                readall.IsBackground = true; // so that when the main thread finishes, the app closes
                if (i == 1)
                    readall.Start();
                else
                    Console.WriteLine("Error");
                return i;
            }
    
            public static void readAllMessage()
            {
                while (true)
                {
                    Console.WriteLine("reading...");
                    Thread.Sleep(500);
                }
            }
    
            public static int startServer()
            {
                return 1;
            }
    
    
            private static void Main(string[] args)
            {
                var i = Intialise();
                Console.WriteLine("Init finished, thread running");
                Console.ReadLine();
            }
        }
