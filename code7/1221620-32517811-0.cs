	public static bool CallMethodA(string p1)
    {
        try 
		{
			return(_Provider.WebMethodA(p1));  
		}
		catch (Exception ex) // normally just catch the exceptions of interest
		{
			// recreate
			_Provider = new com.mysite.service1();
			// try once more.  
			return(_Provider.WebMethodA(p1));  			
		}
		
    }
