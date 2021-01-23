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
    	throw new FaultException("Exception reading product numbers: " + e.Message, new FaultCode("Read/GetString"));
    }
