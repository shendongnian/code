    using(SqlConnection connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        string sql =  "INSERT INTO MyTable(name, lastname) VALUES(@param1,@param2)";
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.Add("@param1", SqlDbType.Varchar, 50).value = myFirstname;
            cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value = myLastName;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
    
        connection.Close();
    }
