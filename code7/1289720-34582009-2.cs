    public class FileCheckServivce : System.ServiceProcess.ServiceBase  
    {
    	System.Timers.Timer timer = new System.Timers.Timer(1000);
    	
    	pub FileCheckServivce()
    	{
    		timer.Elapsed +=TimerTicked;
    		timer.AutoReset = true;
    		timer.Enabled = true;
    	}
    	
    	protected override void OnStart(string[] args)
    	{
    		timer.Start();
    	}
    
    	private static void TimerTicked(Object source, ElapsedEventArgs e)
        {
            if(!File.Exists(@"C:\Users\john\logOn\oauth_url.txt")) 
    			return;
    
            //if file exists do stuff else timer will tick after another second.
        }
    }
