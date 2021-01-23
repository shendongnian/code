    string command1 = "SELECT Column1, Column2, Column3 FROM Table1";
    string command2 = "UPDATE Table2 SET Column2 = @var2, Column3 = @var3 WHERE Column1 = @var1";
    
    using (SqlCeCommand cmd1 = new SqlCeCommand(command1, connection))
    {
         // define your "cmd2" here, once, before the loop
         SqlCeCommand cmd2 = new SqlCeCommand (command2, connection);
    
         // define the parameters
         cmd2.Parameters.Add("@var1", SqlDbType.Int);
         cmd2.Parameters.Add("@var2", SqlDbType.Int);
         cmd2.Parameters.Add("@var3", SqlDbType.VarChar, 100);
    
         SqlCeDataReader reader = cmd1.ExecuteReader();
    
         while (reader.Read())
         {
             int var1 = (int)reader[0];
             int var2 = (int)reader[1];
             string var3 = (string)reader[2];
    
             // set the *values* of the parameters
             cmd2.Parameters["@var1"].Value = var1;
             cmd2.Parameters["@var2"].Value = var2;
             cmd2.Parameters["@var3"].Value = var3;
    
             cmd2.ExecuteNonQuery();
         }
    }
