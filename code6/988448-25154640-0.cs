    String sql=@"SELECT Column1, Column2 
                 FROM Table
                 WHERE Column1 = @str AND Column2 > @val
                 ORDER BY Column1";
    using(var connection = new SqlConnection(_connectionString)
    using(var command = new SqlCommand(sql, connection)
    {
        connection.Open();
        command.Parameters.Add("@str", SqlDbType.NVarChar, Column1MaxTextLength).Value = str;
        command.Parameters.Add("@val", SqlDbType.Int).Value = val;
        using(var reader = command.ExecuteReader())
        {
            //...
        }
    }
