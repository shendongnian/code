    public class executeSQL
    {           
         private void CheckSQLConnection(SqlConnection con)
         {
           ...
         }     
         public void executeQuery(string sql)
         {
             using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
             {
                 con.Open();
                 using (var cmd = new SqlCommand(sql, con))
                 {
                     CheckSQLConnection();
                     cmd.ExecuteNonQuery();
                 }
                 con.Close();
             }
         }
     }
