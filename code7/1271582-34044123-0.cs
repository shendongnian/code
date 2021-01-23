    public static async Task<A_Class> AStaticMethodAsync(SqlConnection dbConn, Guid A_Param)
    {
      try
      {
        if (dbConn.State != ConnectionState.Closed) dbConn.Close();
        using (var cmd = new SqlCommand("MyStoredProc", dbConn))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@sp_Param", SqlDbType.UniqueIdentifier).Value = A_PAram
          await dbConn.OpenAsync();
          using(SqlDataReader reader = await cmd.ExecuteReader())
          {
            var A_Class = StaticFunctionToGetInstanceOfClassFromResults( reader );
            A_Class.rc = 1;
            return A_Class
          }
        }
      }
      catch (Exception)
      {
        //server error
        // Why are you wrapping an exception instead of just passing it up the stack? This is weird.
        return new A_Class(A_ClassError.beApiError);
      }
    }
