    try
    {
        Connect();
        ... do other stuff
    }
    catch (Exception exc)
    {
         ... process exception
    }
    finally
    {
        Disconnect();
    }
