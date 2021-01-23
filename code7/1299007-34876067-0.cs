    public class Program
    {
    	public static void Main()
    	{
    		LockSample lockObject = LockSample.GetInstance();
    		lock(lockObject)
    		{
    		  lockObject.MethodA();
    		}
    	}
    }
    
    public class LockSample
    {
        private static LockSample _Lock;
        public static LockSample GetInstance()
        {
           if(_Lock == null)
           {
              _Lock = new LockSample();
           }
           return _Lock;
        }
    	
    	public void MethodA()
    	{
    	   Console.WriteLine("MethodA Called");
    	   MethodB();
    	}
    	
    	private void MethodB()
    	{
    	  Console.WriteLine("MethodB Called");    	
    	}
    }
