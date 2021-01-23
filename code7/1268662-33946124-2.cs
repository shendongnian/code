    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static Timer _timer;
    
            private static void Main(string[] args)
            {
                _timer = new Timer(state => { 
                    Console.WriteLine("Doing something"); 
                 }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
    
                Console.WriteLine("Press ENTER to quit the application");
                Console.ReadLine();
            }
        }
    }
