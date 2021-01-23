    using (SqlConnection con = new SqlConnection(ConStr))
    {
        string query = @"INSERT INTO tblExpEntry
        (RemainingPayment , CHQNo, TransactionID)
         VALUES(@total, @chq, @transid)";
        using (SqlCommand cmd = new SqlCommand(query,con))
        {
            con.Open();
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = Convert.ToDecimal(tbRemainingPayment.Text);
            cmd.Parameters.Add("@CHQNo", SqlDbType.NVarChar).Value =  tbCHQNo.Text;
            cmd.Parameters.Add("@transid", SqlDbType.NVarChar).Value =  lbl_ID.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Transaction Successful.", "Created");
            generateTransactionID();
        }
    }
 
