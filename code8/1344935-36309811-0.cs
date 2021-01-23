    void Main()
    {
        var a = new A();
        a.Start();
        a.FinishedEvent.WaitOne();
        Console.WriteLine(a.Index);
    }
    // Define other methods and classes here
    public class A
    {
        ManualResetEvent mre = new ManualResetEvent(false);
        int i;
        public EventWaitHandle FinishedEvent
        {
            get { return mre; }
        }
        public int Index
        {
            get { return i; }
        }
        
        public A()
        {
            i = 0;
        }
        protected void RunLoop()
        {
            while (i < 1000)
            {
                i++;
            }
            mre.Set();
        }
        public void Start()
        {
            var runThread = new Thread(new ThreadStart(RunLoop));
            runThread.Start();
        }
    }
