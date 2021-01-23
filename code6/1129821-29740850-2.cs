    If (reader.Read())
    {
        TextBox6.Text = reader.GetString(reader.GetOrdinal("Model"));
     reader.Close();
     }
