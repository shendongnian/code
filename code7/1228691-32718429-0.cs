    class Test
    {
    	public static void SayHello()
    	{
    		Console.WriteLine("Hello");
    	}
    }
    
    void Main()
    {
    	var t = new Test();
    	var methodInfo = t.GetType().GetMethod("SayHello");
    	methodInfo.Invoke(t, null);
    	
    }
    
