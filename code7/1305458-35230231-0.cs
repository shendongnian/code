    NpgsqlCommand cmd = new NpgsqlCommand("select * from my_box", conn);
    NpgsqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        NpgsqlBox b = (NpgsqlBox)reader.GetValue(0);
    }
    reader.Close();
