	void Main()
	{
		Object obj = new Object();
		Func<object> action = ()=> obj; ;
		MethodInfoInvoke(action);      // accepted!
	}
	
