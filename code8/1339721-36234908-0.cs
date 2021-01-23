    try
    {
    	using (var outerContext = new testEntities())
    	{
    		var outerCust1 = outerContext.Customer.FirstOrDefault(x => x.Id == 1);
    		outerCust1.Description += "modified by outer context";
    		using (var innerContext = new testEntities())
    		{
    			var innerCust1 = innerContext.Customer.FirstOrDefault(x => x.Id == 1);
    			innerCust1.Description += "modified by inner context";
    			innerContext.SaveChanges();
    		}
    		outerContext.SaveChanges();
    	}
    }
    catch (DbUpdateConcurrencyException ext)
    {
    	Console.WriteLine(ext.Message);
    }
