        var crmSvc = new CrmServiceClient(<CONNECTION STRING>);
    
    	var contactQuery = new QueryExpression("contact")
    	{
    		ColumnSet = new ColumnSet("firstname", "lastname")
    	};
    	var contacts = crmSvc.RetrieveMultiple(contactQuery).Entities;
    	foreach(var contact in contacts)
    	{
    		Console.WriteLine("Contact name: {0} {1}", contact.GetAttributeValue<String>("firstname"), contact.GetAttributeValue<String>("lastname"));
    	}
