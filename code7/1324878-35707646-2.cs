    public class AskingForWorkClass
    {
        private static Timer _timer;
    	private AutoResetEvent _event = new AutoResetEvent(true);
    	
        public void Start()
            {
                // catchup with outstanding work
                DoWork(this, null);
    
            _timer = new Timer { Interval = 1000 }; // one second
            _timer.Elapsed += DoWork;
            _timer.Start();
            }
    
            private void DoWork(object sender, EventArgs e)
            {
    			_event.WaitOne();
    			
    			// ... do stuff here ... 
    			
    			_event.Set();
            }
    }
