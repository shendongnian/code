    var query = _DBContext
    	.Database
    	.SqlQuery<MyModel>("SELECT * FROM MyModel");
    
    var result = new List<MyModel>();
    var enumerator = query.GetEnumerator();
    while (true)
    	{
    	try
    		{
    		var success = enumerator.MoveNext();
    		if (!success)
    			break;
    
    		var model = enumerator.Current;
            result.Add(model);
    		}
    	catch (Exception ex)
    		{
    		}
    	}
    return result;
