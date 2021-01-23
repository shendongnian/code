      public void CreateDatabase(String createDb)
             {
                 String connstr = ConfigurationManager.ConnectionStrings["Connstr"].ToString();
                 MySqlConnection cnn = new MySqlConnection(connstr);
    
                 try
                 {
                     cnn.Open();
                     object result = string.Empty;
                     MySqlCommand Command = new MySqlCommand();
                     Command = cnn.CreateCommand();
                     Command.CommandType = CommandType.Text;
                     Command.CommandText = Query;
                     Command = new MySqlCommand(Query, cnn);
                     //result = (object)NpgCommand.ExecuteScalar();
                     Command.ExecuteNonQuery();
    
    
    
                 }
                 catch (Exception er)
                 {
                     String errorhere = er.Message;
                     if (cnn != null)
                     {
                         cnn.Close();
                     }
    
                    
                 }
                 finally
                 {
                     if (cnn != null)
                     {
                         cnn.Close();
                     }
                 }
    
             }
