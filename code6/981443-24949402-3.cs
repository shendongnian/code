    var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"];
    try
    {
       SqlCommand command = new SqlCommand("SELECT ...", dbSqlConnection);
       dbSqlConnection.Open();
       // execute the SqlCommand e.g. ExecuteReader, ExecuteNonQuery, ExecuteScalar 
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
