    namespace Test
    {
        class Program
        {
            public static System.Timers.Timer timer_get = new System.Timers.Timer();
            
            public static void Main()
            {
                timer_get.Elapsed += new ElapsedEventHandler(Get_OnTimedEvent);
                timer_get.Interval = 1000;
                timer_get.AutoReset = false;
                timer_get.Enabled = true;
    
                Console.WriteLine("Any Key to Exit");
                Console.ReadLine();
    
            }
    
            private static void Get_OnTimedEvent(object sender, ElapsedEventArgs e)
            {
                try
                {
                    GetListFromDb();
                }
                finally
                {
                    timer_get.Start();
                }
            }
    
            public static void GetListFromDb()
            {
                try
                {
                    Thread.Sleep(5000);
                    //..
                    //..
                    //..
                }
                catch (Exception e)
                {
                    //..
                }
            }
        }
    }
