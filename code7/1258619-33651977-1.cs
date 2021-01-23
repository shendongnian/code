    using System.Timers;
    public class Test
    {
        DateTime StartTime { get; set; }
        TimeSpan TimePlayed { get; set; }
        Timer Timer { get; set; }
    
        public Test()
        {
            Timer = new Timer() {Interval = 1000};
            Timer.Elapsed += Update;
            Timer.Start();
            StartTime = DateTime.Now;
        }
    
        private void Update(object sender, ElapsedEventArgs e)
        {
            TimePlayed = DateTime.Now - StartTime;
        }
    }
