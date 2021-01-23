    public bool Delete(int RGP) {
      // Argument/State validation
      if (objCon == null)
        return false; // No connection
    
      // SQL should be readable
      vsql = @"delete 
                 from Pescador 
                where Rgp like @RGP";
    
      try {
        // Dispose IDisposable (via using)
        using (SqlCommand cmd = new SqlCommand(vsql, objCon)) {
          cmd.Parameters.AddWithValue("@RGP", RGP);
    
          return cmd.ExecuteNonQuery() > 0;
        }
      }
      finally {
        Desconectar();
      }
    }
