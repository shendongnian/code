    using (var reader = yourCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            string column1 = (string)reader["Column1"];
            string column2 = (string)reader["Column2"];
            if (!dict.ContainsKey(column1))                     
                dict.Add(column1, new List<string>()); 
            dict[column1].Add(column2); 
        }
    }
