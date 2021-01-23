    string sql = @"INSERT INTO Order ([LedgerNumber], [OrderNumber], [OrderDate], [PendingDateTime], [EmailAddress]) 
                   VALUES (1, @OrderNumber, @OrderDate, @PendingDateTime, @EmailAddress)";
    using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OrderContext"].ConnectionString))
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        cmd.Parameters.AddWithValue("@OrderNumber", rec.OrderNumber);
        cmd.Parameters.AddWithValue("@OrderDate", rec.OrderDate);
        cmd.Parameters.AddWithValue("@PendingDateTime", rec.PendingDateTime);
        cmd.Parameters.AddWithValue("@EmailAddress", rec.EmailAddress);
        con.Open();
        cmd.ExecuteNonQuery(); 
    }
