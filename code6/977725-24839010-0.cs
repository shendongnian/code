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
             }
        }
    }
