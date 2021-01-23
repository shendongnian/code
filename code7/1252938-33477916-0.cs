    string localdb = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    
    try
    {
    	SqlConnection con = new SqlConnection(localdb))
    
    
    	con.Open();
    
    	SqlCommand cmd = new SqlCommand("INSERT INTO Customer(CustID, CustName, ICNumber, ContactNumber, Address) VALUES (@CustID, @CustName, @ICNumber, @ContactNumber, @Address)", con);
    	cmd.Parameters.AddWithValue("@CustID", txtCustID.Text);
    	cmd.Parameters.AddWithValue("@CustName", txtCustName.Text);
    	cmd.Parameters.AddWithValue("@ICNumber", txtICNum.Text);
    	cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text);
    	cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
    	cmd.ExecuteNonQuery();
    }
    catch
    {
    	// some errors 
    }
    finally 
    {
    	if (con.State == ConnectionState.Open)
    	   con.Close();
    }
