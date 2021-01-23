    try
    {
        Con.Open();
    } 
    catch (Exception e){
    	// handle error
    	Console.WriteLine("Possible MySQL Exception: " + e);
    }
