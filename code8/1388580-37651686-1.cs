    public string SomeMethod()
    {
		try
		{
            //Path 1
            return "Path 1";
		}
		catch (SqlException ex)
		{
            if (...) {
                 //Path 2
                 return "Path 2";              
            }
           //Path 3
           //Return or rethrow.
           //return "Path 3";
           throw;
		}
		finally
		{
            //Clean Up Resources
		}
    }
