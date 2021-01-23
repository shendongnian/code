    long size = 0;
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            size += reader.FieldCount;
        }
    }
