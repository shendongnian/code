    try
    {
       using(OracleConnection conn = MakeConnection())
       {
          //do stuff with connection
          //not necessary, but I always manually close connection. Doesn't hurt.
          conn.Close();
       }
    }
    catch(OracleException ex)
    {
        //handle exception.
    }
