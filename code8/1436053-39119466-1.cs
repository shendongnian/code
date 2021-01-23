    var parameter = Expression.Parameter(typeof(HomeTableInvoice), "invoice");
    
    var fieldParameter = Expression.Parameter(typeof(InvoiceCustomFields), "field");
    var anyPredicate = Expression.Lambda(
    	Expression.AndAlso(
    		Expression.Equal(
    			Expression.PropertyOrField(fieldParameter, "FK_CustomFieldHeader"),
    			Expression.Constant("Test")),
    		Expression.Equal(
    			Expression.PropertyOrField(fieldParameter, "Value"),
    			Expression.Constant("42"))),
    	fieldParameter);
    var fieldCondition = Expression.Call(
    	typeof(Enumerable), "Any", new[] { fieldParameter.Type },
    	Expression.PropertyOrField(parameter, "InvoiceCustomFields"), anyPredicate);
    
    // You can use the fieldCondition in your combinator,
    // the following is just to complete the example
    var predicate = Expression.Lambda<Func<HomeTableInvoice, bool>>(fieldCondition, parameter);
    // Test
    var input = new List<HomeTableInvoice>
    {
    	new HomeTableInvoice
    	{
    		InvoiceNumber = "1",
    		InvoiceCustomFields = new List<InvoiceCustomFields>
    		{
    			new InvoiceCustomFields { FK_CustomFieldHeader = "Test", Value = "42" }
    		}
    	},
    }.AsQueryable();
    var output = input.Where(predicate).ToList();
