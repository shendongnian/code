    string Command = "select corporateName, corporateAddress, corporateContact from corporatemembership where corporateID = @CorpID;";
    using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
    {
        using (MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(Command, myConnection))
        {
            myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@CorpID", CorpID.Text));
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            corporateName.Text = dtResult.Rows[0]["corporateName"];
            corporateAddress.Text = dtResult.Rows[0]["corporateAddress"];
            corporateContact.Text = dtResult.Rows[0]["corporateContact"];
        }
    }
