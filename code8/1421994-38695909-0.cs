    string connectionString = ConfigurationManager.ConnectionStrings["StackDemo"]
                     .ConnectionString;
             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 connection.Open();
                 using (SqlCommand cmd = new SqlCommand("LoadStates", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     using (SqlDataReader sdrData = cmd.ExecuteReader())
                     {
                         while (sdrData.Read())
                         {
                           Console.WriteLine( (string)sdrData["stateabbrev"]);
                            
                         }
                         sdrData.Close();
                     }
                 }
             }
