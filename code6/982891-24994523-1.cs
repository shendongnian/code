    try
    {
        // Connection string for a typical local MySQL installation
        string cnnString = "Server=localhost;Port=3306;Database=ci_series;Uid=root;Pwd=";
        // Create a connection object 
        MySqlConnection connection = new MySqlConnection(cnnString);
              
        // Create a SQL command object
        string cmdText = "INSERT INTO webuse(firstName,lastName,age) VALUES(?param1,?param2,?param3)";
       
        MySqlCommand cmd = new MySqlCommand(cmdText, connection);
             
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("?param1", MySqlDbType.VarChar).Value = firstName;
        cmd.Parameters.Add("?param2", MySqlDbType.VarChar).Value = lastName;
        cmd.Parameters.Add("?param3", MySqlDbType.VarChar).Value = age;
               
        connection.Open();
        int result = cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
               
    }
