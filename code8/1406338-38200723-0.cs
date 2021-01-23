    string update = @"UPDATE MosefTransaction 
                      SET TransStatus = 'Approved' 
                      Where TransactionID = @TransactionID";
    using(var updateCommand = new SqlCommand(update, connUser))
    {
        // presuming it's an int
        updateCommand.Parameters.Add("@TransactionID", SqlDbType.Int).Value = int.Parse(lblmosID.Text);
        connUser.Open();
        int affected = updateCommand.ExecuteNonQuery();
    }
         
