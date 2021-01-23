    string sqlQuery = "INSERT INTO testing.customers (itemTitle, itemContent, itemPrice) VALUES(@title, @content, @price)";
    using (var connection = new SqlConnection("connectionString"))
    {
        using (var cmd = new SqlCommand(sqlQuery, connection))
        {
            cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
            ...
            connection.Open();
            cmd.ExecuteNonQuery(); //You were missing this
        }
    }
