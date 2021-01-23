    MySqlCommand query = new MySqlCommand();
    query.Connection = _connection;
    query.CommandText = "SELECT * FROM Photos WHERE id=@ID";
    query.Parameters.Add("@id", MySqlDbType.Binary).Value = guid.ToByteArray();
    
    using (MySqlDataReader reader = query.ExecuteReader())
    {
        if (reader.Read())
        {
            Guid id = reader.GetGuid(0);
            byte[] imgBuffer = (byte[])reader.GetValue(1);
        }
    }
