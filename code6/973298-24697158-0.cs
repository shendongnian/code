    public void GetOne(/* connectionString, string invref, string tableref*/)
    {
        getCommand = "select *redacted* from " + tableref + "where *redacted* = " + invref;
        using (SqlConnection dbConnection = new SqlConnection(DBConnection.DBConnection.connectionString))
        {
            dbConnection.Open();
            holdone.SelectCommand = new SqlCommand(getCommand, dbConnection);
            holdone.Fill(holdall);
            invoiceTable = holdall.Tables[0];
            //dbConnection.Close(); // This line is unnecessary, as the connection will be closed by `using`
        }
        DataRowView rowView = invoiceView.AddNew();
        rowView["*redacted*"] = invoiceTable;
        rowView.EndEdit();
    }
