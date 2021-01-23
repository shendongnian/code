<!-- -->
    public class Program
    {
    	public static void Main()
    	{
    		var dev = new Developer();
    		dev.Register("senior");	
    		
    		IEmployee e = dev;
    		e.Register("senior");	
    	}
    }
