    try
    {
      using (var oraclePackage = new OraclePackage())
        {
            if (_dbConn.State != ConnectionState.Open)
                _dbConn.Open();
            // some DB functions here 
        }
    }
    finally
    {  _dbConn.Close(); }
