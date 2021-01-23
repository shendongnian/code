    //rename ct1, ct and fields to something meaningful. This will help you when you have ct1-ct1000 :)
            using(SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["WebTeamServersConnectionString"].ConnectionString))
            {
              string[] words1 = fields.Split(',');
              #region Build UPDATE SqlQuery
              string sql = "UPDATE [Web Team Servers] SET ";
              
              foreach (string s1 in words1)
              {
                if (ct1 == 1)
                {
                    sql = sql + s1 + " = '@Param" + ct1 + "'";
                }
                else
                {
                    sql = sql + ", " + s1 + " = '@Param" + ct1 + "'";
                }
                ct1 = ct1 + 1;
              }
              sql = sql + " WHERE Server = @Server";
              #endregion
              //have to open your connection first
              cn1.Open();
              //begins the transaction
              SqlTransaction transaction = cn1.BeginTransaction();
              //hook up your transaction to the command in question
              using (SqlCommand cmd = new SqlCommand(sql,cn1,transaction))
              {
                  
                try
                {
                   cmd.Parameters.AddWithValue("@Server", strServer);
                   string[] words = values.Split(',');
                   foreach (string s in words)
                   {
                     string param = "@param" + ct;
                     cmd.Parameters.AddWithValue(param, s);
                     ct = ct + 1;
                   }
                   cmd.CommandType = CommandType.Text;
                   //will commit automagically
                   int rows = cmd.ExecuteNonQuery();
                   //makes it super obvious we agree with the transaction
                   transaction.Commit();
                }
                catch (Exception ex)
                {
                  //if shiite hits the fan undo changes to db
                  transaction.Rollback();
                     
                  Console.WriteLine(ex.Message+","+ex.StackTrace);
                }
    
              }
            }
      
    
