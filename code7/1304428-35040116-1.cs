    List<string> result = new List<string>();
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            result.Add(reader.GetString(0));
        }
    }
