        try
    {
        // attempt to do something here
    	con.Open();
    } 
    catch (Exception e){
    	// handle error
    	Console.Writeline("Exception: " + e);
    }
    finally 
    {
    	Console.Writeline("This runs no matter if an exception is thrown or not!");
    }
    
    Console.Read();
