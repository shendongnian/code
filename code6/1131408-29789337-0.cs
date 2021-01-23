    public class CheckAuctionsScheduleModule : IHttpModule
    {
        static Timer timer;
        long interval = 60000; //60 secs
        static object synclock = new object();
        public void Init(HttpApplication app)
        {
            if(timer==null) timer = new Timer(new TimerCallback(CheckAuctions), null, 0, interval);
        }
     
        private void CheckAuctions(object obj)
        {
            lock (synclock)
            {
               //implement here your logic
               //check completed auctions
    	       //send notifications to bidder etc.  
    
            }
        }
        public void Dispose()
        { 
    	//implement if needed
        }
    }
