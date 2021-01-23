    try
    {
        ConnectToDatabase();
    }
    catch(SqlException ex)
    {
        //Now we know a SQL exception has occurred, perhaps check the Number property?
        if(ex.Number == 18456) 
        {
            //Login failed
        }
    }
    catch(Exception ex)
    {
        //General exception handling goes here
    }
