    class Program
        {
            static void Main(string[] args)
            {
                SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
                Console.ReadKey();
            }
    
            static void SystemEvents_TimeChanged(object sender, EventArgs e)
            {
                Console.WriteLine("TimeChanged: {0}", DateTime.Now);
            }
        }
