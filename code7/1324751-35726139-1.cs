      OracleConnection conn = null;
      try
      {
        conn = new OracleConnection(connectionString);
      }
      finally
      {
        if(conn.State != ConnectionState.Closed)
          conn.Close();
      }
