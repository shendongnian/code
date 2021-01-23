    public class FileCheckServivce : System.ServiceProcess.ServiceBase  
    {
    	System.Timers.Timer timer = new System.Timers.Timer(1000);
    	
    	public FileCheckServivce()
    	{
    		timer.Elapsed += TimerTicked;
    		timer.AutoReset = true;
    		timer.Enabled = true;
    	}
    	
    	protected override void OnStart(string[] args)
    	{
    		timer.Start();
    	}
    
    	private static void TimerTicked(Object source, ElapsedEventArgs e)
        {
            if (!File.Exists(@"C:\Users\john\logOn\oauth_url.txt")) 
    			return;
    
            //If the file exists do stuff, otherwise the timer will tick after another second.
        }
    }
