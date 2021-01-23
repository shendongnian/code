    try 
    {
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }
    catch(WebException e) 
	   {
	        Console.WriteLine("\r\nWeb Exception occurred : {0}",e.Status); 
       }
	catch(Exception e)
	{
		Console.WriteLine("Exception: {0}",e.Message);
	}
    
    }
    finally{
    //code after checking http response
    }
