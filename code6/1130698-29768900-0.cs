        class Program
    {
        private static object timercodeRunning = new object();
    
        static void Main(string[] args)
        {
            var timer = new System.Timers.Timer(5000);
    
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
    
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (timercodeRunning)
            {
                try
                {
                    //DO SOME STUFF
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
