    class Program
    {
        private static bool _listnerOn;
        static void Main(string[] args)
        {
            Thread listner = new Thread(EventListnerWork);
            
            listner.Start();
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey(true);
            _listnerOn = false;
            listner.Join();
        }
        static void ConsoleResizeEvent(int height, int width)
        {
            Console.WriteLine("Console Resize Event");
        }
        static void EventListnerWork()
        {
            Console.WriteLine("Listner is on");
            _listnerOn = true;
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            while (_listnerOn)
            {
                if (height != Console.WindowHeight || width != Console.WindowWidth)
                {
                    height = Console.WindowHeight;
                    width = Console.WindowWidth;
                    ConsoleResizeEvent(height,width);
                }
                Thread.Sleep(10); 
            }
            Console.WriteLine("Listner is off");
        }
    }
