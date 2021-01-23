    //validation checks
    else
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        using(MySqlConnection conn = new MySqlConnection(connStr))
        using(MySqlCommand cmd = conn.CreateCommand())
        {
             // Don't need to associate the command to the connection
             // Already done by the CreateCommand above, just need to set
             // the parameters and the command text
             if (questionSource.Equals("S"))
             {
                    cmdText = @"....."
                    cmd.CommandText = cmdText;
                    ....
             }
             else if (questionSource.Equals("U"))
             {
                    cmdText = "........."
                    cmd.CommandText = cmdText;
                    ....
             } 
             try
             {
                  conn.Open();
                  noOfQuestionsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                   ....
              }
        }
    }
