    using System.Windows.Forms;
    using System.Threading;
    namespace ConsoleApplication1
    {
   
    class Program
    {
        
        public static bool run = true;
        static void Main(string[] args)
        {
            
            Startthread();
            Application.Run(new Form1());
            Console.ReadLine();
            
            
        }
        private static void Startthread()
        {
            var thread = new Thread(() =>
            {
                while (run)
                {
                    Console.WriteLine("console is running...");
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }
      }
     }
