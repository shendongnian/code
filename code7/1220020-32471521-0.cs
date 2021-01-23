    static void Main(string[] args)
    {
        Counter c = new Counter( ... );
        c.ThresholdReached += c_ThresholdReached;
        ...
    }
    static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
    {
        Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold,  e.TimeReached);
        ...
    }
    class Counter
    {
        ...
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            //Thread safe event
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
