    static public User WeergevenRolPerUser(string userName)
    {
        try
        {
            using(var connection = new SqlConnection(/* connection string */))
            using(var command = new SqlCommand("select * from [dbo].[fnShowDatabaseRole]('@UserName')", connection))
            {
                 command.Parameters.AddWithValue("@UserName", userName);
                 
                 using(var myReader = command.ExecuteReader())
                 {
                     while(myReader.Read())
                     {
                         return new User
                                    {
                                         Username = myReader.GetString(/* column index */),
                                         Role = myReader.GetString(/* column index */)
                                    }
                     }
                     
                     myReader.Close();
                 }
             }
        catch (SqlException ex)
        {
            throw;
        }
    }
