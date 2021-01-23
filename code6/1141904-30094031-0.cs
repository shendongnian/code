    using(var comm = new SqlConnection())
      using(var comExecuteInsert = new SqlCommand())
      {
        comExecuteInsert.Connection = comm;
        comExecuteInsert.CommandType = CommandType.StoredProcedure;
        comExecuteInsert.CommandText = strProcedureName;
        comExecuteInsert.ExecuteScalar();
        comExecuteInsert.Parameters.Clear();
        comm.Close();
      }    
    SqlConnection.ClearAllPools();
