    connect.GetCustomer((reader =>
    {
        while (reader.Read())
        {
            cmboBoxClient.Items.Add(reader["CustName"] + " " + reader["CustNationality"]);
        }
    }));
