    public class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(ReadKey);
            Thread t = new Thread(ts);
            t.Start();
            while(true)
            {
                Console.WriteLine(DateTime.Now);
                // Simulate some processing
                Thread.Sleep(1000);
            }
        }
        static void ReadKey()
        {
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    Console.WriteLine("Pressed!");
                    Console.ReadKey(true); // Flush the input stream without showing the key on screen.
                }
            }
        }
    }
