     Connection c = new Connection();
     c.OpenCnn();
     try 
     {
          query = "inset into ..."
          cmd = new SqlCommand(query, c.Connection);
          cmd.ExecuteNonQuery();
     }
