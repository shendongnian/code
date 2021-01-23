    private void Count()
    {
        .....
        using(SqlConnection dbCon = new SqlConnection(connectionString))
        using(SqlCommand cmd = new SqlCommand(selectedcmd, dbcon))
        {
             dbcon.Open();
             using(SqlDataReader reader = cmd.ExecuteReader())
             {
                  while (reader.Read())
                  {
                      ......
                  }
             } // Here the reader goes out of scope and it is closed and disposed
        }// Here the connection is closed and together with the command is disposed
    }
