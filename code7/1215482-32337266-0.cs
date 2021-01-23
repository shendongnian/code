    try
    {
        connection.Open();
        using (OleDbCommand command = new OleDbCommand())
        {
            command.Connection = connection;
            command.CommandText = "SELECT CountryName FROM Countries ";
            //whenever you want to get some data from the database
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.NextResult())
                {
                    listBox.Items.Add(reader.GetString(0));
                }
        }
        connection.Close();
        }
    }
    catch (Exception l)
    {
        MessageBox.Show("Error:" + l);
    }
