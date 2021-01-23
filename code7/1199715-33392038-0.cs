        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(String.Format("{0}:{1}:{2} : Timer fired",
                DateTime.Now.ToLocalTime().Hour,
                "Execute:" + DateTime.Now.ToLocalTime().Minute,
                DateTime.Now.ToLocalTime().Second));
        }
