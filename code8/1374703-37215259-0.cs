      using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd = new SqlCommand("sp_GetCategory", con)) {
          cmd.CommandType = CommandType.StoredProcedure;    
          cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = txtFirstName.Text;
    
          con.Open();
          var results = cmd.ExecuteReader();
        }
      }
