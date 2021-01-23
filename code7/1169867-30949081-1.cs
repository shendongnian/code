    using (var db = new Context()) {
        using (var command = db.Connection.CreateCommand())
        {
            command.CommandText = "SELECT y from x order by id";
            using (var reader = command.ExecuteReader())
            {            
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        operateOn(reader.GetString(0));
                    }
                }
            }
        }
    }
