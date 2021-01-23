    List<string> productsList = new List<string>(); 
    try
    {
    	while (productsReader.Read())
    	{
    		string productNumber = productsReader.GetString(0);
    		productsList.Add(productNumber);
    	}
    }catch (Exception e)
    {
    	DatabaseFault df = new DatabaseFault();
    	df.DbOperation = "ExecuteReader";
    	df.DbReason = "Exception querying the AdventureWorks database.";
    	df.DbMessage = e.Message;
    	throw new FaultException<DatabaseFault>(df);
    }
