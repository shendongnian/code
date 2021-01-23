    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        DataSet userDataset = new DataSet();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter(
            "SELECT au_lname, au_fname FROM Authors WHERE au_id = @au_id", 
            connection);                
        myCommand.SelectCommand.Parameters.Add("@au_id", SqlDbType.VarChar, 11);
        myCommand.SelectCommand.Parameters["@au_id"].Value = SSN.Text;
        myDataAdapter.Fill(userDataset);
    }
