    static object _locker = new object();
	public static bool CallMethodA(string p1)
    {
        try 
		{
            // thread locking code omitted
			return(_Provider.WebMethodA(p1));  
		}
		catch (Exception ex) // normally just catch the exceptions of interest
		{
			// recreate
            // thread locking code omitted
			_Provider = new com.mysite.service1();
			// try once more.  
			return(_Provider.WebMethodA(p1));  			
		}
		
    }
