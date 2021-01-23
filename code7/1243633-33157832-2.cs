    public void GetCustomer(Action<SqlDataReader> callback)
    {
        var connString = "connection_string";
        SqlDataReader reader = null;
        var _conn = new SqlConnection(connString);
        string sqlQuery = @"SELECT CustName, CustNationality FROM Customer";
        using (_conn)
        {
            using (SqlCommand cmd = new SqlCommand(sqlQuery, _conn))
            {
                _conn.Open();
                using(reader = cmd.ExecuteReader())
                {
                    callback(reader);
                }
            }
        }
    }
