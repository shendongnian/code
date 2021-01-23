    string InvoiceID;
    string BillingID;
    string Cost;
    string BusinessUnit;
    string Status;
    string InvoiceNumber;
    public static string connectionString = ConfigurationManager.AppSettings("ConnectionString");
    public SqlConnection SqlConnection = new SqlConnection(connectionString);
    public SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
    
    public SqlCommand SqlCommand = new SqlCommand();
    private void insertgrd()
    {
    	foreach (GridDataItem itm in RadGrid1.Items) {
    		InvoiceID = itm.Item("InvoiceID").Text;
    		BillingID = itm.Item("BillingID").Text;
    		Cost = itm.Item("Cost").Text;
    		BusinessUnit = itm.Item("BusinessUnit").Text;
    		Status = itm.Item("Status").Text;
    		InvoiceNumber = itm.Item("InvoiceNumber").Text;
    		try {
    			//Open the SqlConnection
    			SqlConnection.Open();
    			//Update Query to insert into the database
    			string insertQuery = "INSERT into Invoice values('" + InvoiceID + "','" + BillingID + "','" + Cost + "','" + BusinessUnit + "','" + Status + "','" + InvoiceNumber + "')";
    			SqlCommand.CommandText = insertQuery;
    			SqlCommand.Connection = SqlConnection;
    			SqlCommand.ExecuteNonQuery();
    			//Close the SqlConnection
    
    
    			SqlConnection.Close();
    		} catch (Exception ex) {
    			Interaction.MsgBox("Unable to insert. Reason: " + ex.Message);
    
    		}
    
    	}
    }
