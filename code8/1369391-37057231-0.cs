    while (reader.Read())
    {
        if (!comboBox_Owner.Items.Contains(reader["Owner"].ToString()))
            comboBox_Owner.Items.Add(reader["Owner"].ToString());                  
    }
   
