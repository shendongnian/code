        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = "";
        myConnection.Open();
        SqlCommand cmd = new SqlCommand("SELECT CN.ClientID, CN.GivenName1, CN.Surname, CI.DateOfBirth FROM [RioOds].dbo.ClientIndex CI LEFT JOIN [RioOds].[dbo].[ClientName] CN ON CN.ClientID = CI.ClientID AND CN.AliasType = '1' AND CN.EndDate IS NULL WHERE CN.ClientID =" + ClientIDTxt.Text + ";", myConnection);
        var reader = cmd.ExecuteReader();
        StringBuilder sb = new StringBuilder();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (i!=0)
                {
                    sb.Append(",");
                }
                sb.Append(reader[i].ToString());
            }
            sb.AppendLine();
        }
        ResultsLabel.Text = sb.ToString();
