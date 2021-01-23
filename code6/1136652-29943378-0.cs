    if( ( File1.PostedFile != null ) && ( File1.PostedFile.ContentLength > 0 ) )
    {
    	string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
    	string SaveLocation = Server.MapPath("Data") + "\\" +  fn;
    	try
    	{
    		File1.PostedFile.SaveAs(SaveLocation);
    		Response.Write("The file has been uploaded.");
    	}
    	catch ( Exception ex )
    	{
    		Response.Write("Error: " + ex.Message);
    		//Note: Exception.Message returns a detailed message that describes the current exception. 
    		//For security reasons, we do not recommend that you return Exception.Message to end users in 
    		//production environments. It would be better to put a generic error message. 
    	}
    }
    else
    {
    	Response.Write("Please select a file to upload.");
    }
