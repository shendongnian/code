    public void CommitToDatabase()
    {
        using (var con = new SqlConnection(CLSDatabaseDetails.GlobalConnectionString))
        {
            DataTable client = new DataTable();
            string commandString = "SELECT * FROM client";
            SqlCommand cmd = new SqlCommand(commandString, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(client);
            DataRow newClientRow = client.NewRow();
            newClientRow["ClientID"] = ClientID;
            newClientRow["FirstName"] = FirstName;
            newClientRow["LastName"] = LastName;
            newClientRow["Phone"] = PhoneNumber;
            newClientRow["CAddress"] = Address;
            newClientRow["Email"] = Email;
            newClientRow["CUsername"] = Username;
            newClientRow["CPassword"] = Password;
            client.Rows.Add(newClientRow);
            da.Update(client);
        }
    }
