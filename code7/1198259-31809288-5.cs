    string Command =
            @"select corporateName, 
                     corporateAddress, 
                     corporateContact 
                from corporatemembership 
                where corporateID = @CorpID;";
    using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (MySqlCommand cmd = new MySqlCommand(Command, mConnection))
        {
            cmd.Parameters.Add(new MySqlParameter("@CorpID", CorpID.Text));
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    corporateName.Text = (string)reader["corporateName"];
                    corporateAddress.Text = (string)reader["corporateAddress"];
                    corporateContact.Text = (string)reader["corporateContact"];
                }
            }
        }
    }
