    try
    {
        HttpContext ctx = HttpContext.Current;
        System.Threading.Tasks.Task.Factory.StartNew(() =>
        {
    		try
    		{
    			HttpContext.Current = ctx;
    			System.Threading.Thread.Sleep(5 * 60 * 1000);
    			Sendafter5mins(param1,params2);
    		}
    		catch(Exception e)
    		{
    			//Log Exception if any
    		}
    			
        });
    }
    catch (Exception EX)
    {
        //This will catch unlikely exceptions thrown from HttpContext ctx = HttpContext.Current 
    	//	or the creation of the Task
    }
 
