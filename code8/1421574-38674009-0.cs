    if (j.Connect(out j))
    {                        
         str2 = "SELECT CPU FROM Clients WHERE CPU = @cpu";
         using(connection = new SqlConnection(str))
         using(SqlCommand command = new SqlCommand(str2, connection);
         {
             connection.Open();
             command.Parameters.Add("@cpu", SqlDbType.NVarChar).Value = j.GetCPUKey());
             using(reader = command.ExecuteReader())
             {
                 if(reader.HasRows)
                 {
                    MessageBox.Show("Authenticated");
                    j.XNotify("Connected! Welcome: " + j.GetCPUKey());
                    CheckAuth();
                 }   
                 else
                    MessageBox.Show("Unauthorized");
             }
        }
    }
