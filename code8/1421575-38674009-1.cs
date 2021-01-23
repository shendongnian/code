    try
    {
        if (j.Connect(out j))
        {       
             string cpuToSearchFor = j.GetCPUKey();
             str2 = "SELECT CPU FROM Clients WHERE CPU = @cpu";
             using(connection = new SqlConnection(str))
             using(SqlCommand command = new SqlCommand(str2, connection);
             {
                 connection.Open();
                 command.Parameters.Add("@cpu", SqlDbType.NVarChar).Value = cpuToSearchFor;
                 using(reader = command.ExecuteReader())
                 {
                     if(reader.HasRows)
                     {
                        MessageBox.Show("Authenticated");
                        j.XNotify("Connected! Welcome: " + cpuToSearchFor);
                        CheckAuth();
                     }   
                     else
                        MessageBox.Show("Unauthorized");
                 }
            }
        }
    }
    catch(Exception ex)
    {
       MessageBox.Show("" + ex);
       Environment.Exit(0);
    }
