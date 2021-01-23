    public DataTable GetCustomers()
    {
    	SqlDataAdapter adapter = new SqlDataAdapter(
    	  "SELECT firstName,lastName,phoneNumber FROM customers", conn);
    
    	DataSet custDS = new DataSet();
    	adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    	adapter.Fill(custDS, "Customers");
    
    	return custDS.Tables[0];
    }
