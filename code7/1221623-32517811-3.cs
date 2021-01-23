	public static class WebMethodWrapper
	{
		static com.mysite.service1 _Provider = null;
		static object _locker = new object();
		static WebMethodWrapper()
		{
			_Provider = new com.mysite.service1();
		}
		static com.mysite.service1 Client
		{
			get
			{
				lock (_locker)
				{
					return _Provider;
				}
			}
		}
		public static bool CallMethodA(string p1)
		{
			try
			{
				return (Client.WebMethodA(p1));
			}
			catch (Exception ex) // normally just catch the exceptions of interest
			{
				// Excercise for reader - use a single method instead of repeating the below
				// recreate
				var c = RecreateProxy();
				// try once more.  
				return (c.WebMethodA(p1));
			}
		}
		public static bool CallMethodB(string p1)
		{
			try
			{
				return (Client.WebMethodB(p1));
			}
			catch (Exception ex) // normally just catch the exceptions of interest
			{
				// Excercise for reader - use a single method instead of repeating the below
				// recreate
				var c = RecreateProxy();
				// try once more.  
				return (c.WebMethodB(p1));
			}
		}
		static com.mysite.service1 RecreateProxy()
		{
			lock (_locker)
			{
				_Provider = new com.mysite.service1();
				return _Provider;
			}
		}
	}
