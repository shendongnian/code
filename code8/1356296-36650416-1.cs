    string query = @"select userid from register 
                    where username = @name and password = @pwd";
    using(SqlCommand cmd1 = new SqlCommand(query,connection))
    {
        connection.Open();
        cmd1.Parameters.Add("@name", SqlDbType.NVarChar).Value = UserName.Text;
        cmd1.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = Password.Text;
        using(SqlDataReader rd1 = cmd1.ExecuteReader())
        {
            ....
        }
    }
