    var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"];
    try
    {
        
    }
    finally
    {      
        if (dbSqlConnection != null)
            ((IDisposable)dbSqlConnection).Dispose();
    }
