    using (NpgsqlCommand cmd = new NpgsqlCommand(
            String.Format("select pid,name from queue order by id"), conn))
    {
        using (NpgsqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                queue[(int)reader["pid"]] = (string)reader["name"];
            }
        }
    }
