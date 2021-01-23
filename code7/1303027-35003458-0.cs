    void Application_Error(object sender, EventArgs e)
    {
    	try
    	{
    		Exception exception = Server.GetLastError();
    		Server.ClearError();
    		if(exception != null)
    		{
    		  // Do Some Stuff!
    		}
    	}
    	catch(Exception ex)
    	{
    	}
    }
