    string PROPCODE = "IMPORT_" + ID;
    string leadtenant = clcodet;
    
    using (OleDbCommand tenantpopulation = new OleDbCommand(@"SELECT
    CLCODE
    FROM CLIENT WHERE PROPCODET = ?", importConnection))
    {
        tenantpopulation.Parameters.AddWithValue("p", PROPCODE);
    	
    	// rest of code seem to be meaningless
    	// and I didn't see any code where you run your query
    	// depending on your requirement, I assume PROPCODET is a primary key?
    	// if so then you to do the check you only need to return the CLCODE
    	// with ExecuteScalar:
    	
        importConnection.Open();
    	var clcode = (string)tenantpopulation.ExecuteScalar();
        importConnection.Close();    	
    	
        string tenants = "";
    	
    	// in C# equality check is done with == NOT = (assingment)
    	if (clcode == leadtenant)
    	{
    		// tenants is always String.Empty here
    		if (tenants != String.Empty)
    		{
    			//do something
    		}
    	}
    }
