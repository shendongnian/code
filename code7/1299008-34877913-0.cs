    public class Program
    {
	    public static void Main()
    	{
	    	LockSample lockSampleInstance = LockSample.GetInstance();
            lockSampleInstance.MethodA();
    	}
    }
    public class LockSample
    {
    	private static readonly LockSample INSTANCE = new LockSample();
	    private static Object lockObject = new Object();
    
    	public static LockSample GetInstance()
    	{
	    	return INSTANCE;
    	}
	    public void MethodA()
    	{
	       Console.WriteLine("MethodA Called");
    	   MethodB();
	    }
     	private void MethodB()
    	{
	    	lock(lockObject)
    		{
	    		Console.WriteLine("MethodB Called");      
    		}
	    }
    }
