    // suppose customer ID is an integer
    int customerId = 0;
    string customerName = (string)Session["New"];
    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
    	SqlCommand sqlCmd = new SqlCommand("SELECT id FROM CustomerDetails WHERE CustomerName = @customerName", sqlCon);
    	sqlCmd.Parameters.AddWithValue("@customerName", customerName);
    	object result = sqlCmd.ExecuteScalar();
    	if (result != null)
    		customerId = (int)result;
    }
