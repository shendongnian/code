    public class TimeDemo
    {
        // Property to catch the timespan
        public TimeSpan TimeOfState { get; set; }
        // Full Property for the state
        private bool state;
        
        public bool State
        {
            get { return state; }
            set
            {
                // whenever a new state value is set start measuring
                state = value;
                this.TimeOfState = StopTime();
            }
        }
        // Use this to stop the time
        public System.Diagnostics.Stopwatch StopWatch { get; set; }
        public TimeDemo()
        {
            this.StopWatch = new System.Diagnostics.Stopwatch();
        }
        //Method to measure the elapsed time
        public TimeSpan StopTime()
        {
            TimeSpan t = new TimeSpan(0, 0, 0);
            if (this.StopWatch.IsRunning)
            {
                this.StopWatch.Stop();
                t = this.StopWatch.Elapsed;
                this.StopWatch.Restart();
                return t;
            }
            else
            {
                this.StopWatch.Start();
                return t;
            }
        }
        public void Demo()
        {
            Console.WriteLine("Please press Enter whenever you want..");
            Console.ReadKey();
            this.State = !this.State;
            Console.WriteLine("Elapsed Time: " + TimeOfState.ToString());
            
            Console.WriteLine("Please press Enter whenever you want..");
            Console.ReadKey();
            this.State = !this.State;
            Console.WriteLine("Elapsed Time: " + TimeOfState.ToString());
            Console.WriteLine("Please press Enter whenever you want..");
            Console.ReadKey();
            this.State = !this.State;
            Console.WriteLine("Elapsed Time: " + TimeOfState.ToString());
        }
    }
