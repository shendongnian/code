    var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"];
    try
    {
    
    }
    catch (Exception ex)
    {
       // handle the exception
    }
    finally
    {   
        // this gets called even if a exception has occured   
        if (dbSqlConnection != null)
           dbSqlConnection.Dispose();
    }
