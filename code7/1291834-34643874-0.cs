        String ConnectionString = @"DataSource=LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer\Documents\Data.mdf;Integra‌​ted Security=True;Connect Timeout=30;";
        String QueryString = @"Select Count (*) From dbo.Table where Username= @Username and Password = @Password";
    
         SqlParameter[] Parameters = {new SqlParameter("Username",textBox1.text)
                                     ,new SqlParameter("Password",textBox2.text)};
    
    
         SqlConnection sqlConnection = new SqlConnection(ConnectionString);
         SqlCommand sqlCommand = new SqlCommand(QueryString, sqlConnection);
         sqlCommand.CommandType = System.Data.CommandType.Text;
    
         sqlCommand.Parameters.AddRange(Parameters);
    
         int nCount;
         if (int.TryParse(sqlCommand.ExecuteScalar().ToString(), out nCount))
         {
             //nCount has valid value
         }
         else
         {
             //nCount has invalid value
         }
 
