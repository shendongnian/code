    try
    {
    	var userid = Convert.ToInt32(Console.ReadLine());
    	var aquery2 = from test in context.BusinessEntityAddress
    				  where test.Address.StateProvinceID == userid
    				  group test.BusinessEntity.Person.LastName by new { test.BusinessEntityID, test.BusinessEntity.Person.LastName, test.BusinessEntity.Person.FirstName } into balk
    				  select new
    				  {
    					  /* ... */
    				  };
    	if (!aquery2.Any())
    	{
    		// not found... display a message
    	}
    	else
    	{
    		// found... do stuffs
    	}
    }
