    interface ISomething
	{
		T Method<T>();
	}
	
	class SomethingWithString : ISomething
	{
		public string Method<string>()
        {
        	return "Hello World !";
        }
	}
	
	class SomethingWithInt : ISomething
	{
		public int Method<int>()
		{
			return 42;
		}
	}
