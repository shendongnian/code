    private static int MyProperty
    {
    	get
    	{
    		try
    		{
    			return 10 / Convert.ToInt32("0");
    		}
    		catch (Exception e)
    		{
    			return -1;
    		}
    	}
    }
