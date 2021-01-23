    private int a;
    private AutoResetEvent newResult = new AutoResetEvent(false);
    
    private void ThreadA()
    {
    	while (true)
    	{
    		a = GetSensorA();
    		newResult.Set();
    	}
    }
    
    private void ThreadB()
    {
    	int b = GetSensorB();
    
    	while (true)
    	{
    		newResult.WaitOne();
    		newResult.Reset();
    		Console.WriteLine(a + b); // do something
    		b = GetSensorB();
    	}
    }
