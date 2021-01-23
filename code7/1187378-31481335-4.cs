    static class Test
    {
    	public static void SomeMethod<T>(Func<T> f)
    	{
    		Console.WriteLine((T)(f()));
    	}
    }
	SomeMethodInvoker(typeof(Test), 3);
	object obj = "test";
	
	SomeMethodInvokerRuntime(typeof(Test), obj);
