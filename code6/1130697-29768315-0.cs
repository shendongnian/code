    class Program
    {
        private static bool timercodeRunning;
        static void Main(string[] args)
        {
            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!timercodeRunning)
            {
                timercodeRunning = true;
                try
                {
                    //DO SOME STUFF
                    timercodeRunning = false;
                }
                catch (Exception)
                {
                    timercodeRunning = false;
                    throw;
                }
            }
        }
    }
