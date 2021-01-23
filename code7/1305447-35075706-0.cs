    using(var reader = command.ExecuteReader();)
    {
        while (reader.Read())
            {
                skuList.Add(reader.GetString(0));
            }
    }
    connection.Dispose();
