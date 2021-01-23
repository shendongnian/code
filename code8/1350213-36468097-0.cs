    foreach (var model in deserializeObject.Model)
    {
    	foreach (var table in model.Table)
    	{
    		if(table is KeyValuePair<string, object>)
    		{
    			foreach (var row in table.Value)
    			{
    				Console.WriteLine(row.BookId + ": " + row.BookName);
    			}
    		}
    		else
    		{
    			foreach (var row in table.Row)
    			{
    				Console.WriteLine(row.BookId + ": " + row.BookName);
    			}
    		}
    	}
    }
