    decimal remainingPayment;
    if(!decimal.TryParse(tbRemainingPayment.Text, out remainingPayment))
    {
        // Add a message for your user and return, or continue 
        // inserting the default value for a decimal (that's zero)
    }
    using (SqlConnection con = new SqlConnection(ConStr))
    {
        string query = @"INSERT INTO tblExpEntry
        (RemainingPayment , CHQNo, TransactionID)
         VALUES(@total, @chq, @transid)";
        using (SqlCommand cmd = new SqlCommand(query,con))
        {
            con.Open();
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = remainingPayment;
            cmd.Parameters.Add("@chq", SqlDbType.NVarChar).Value =  tbCHQNo.Text;
            cmd.Parameters.Add("@transid", SqlDbType.NVarChar).Value =  lbl_ID.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Transaction Successful.", "Created");
            generateTransactionID();
        }
    }
 
