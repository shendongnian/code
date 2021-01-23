    foreach (var rec in q)
    {
    	Console.Write("File = {0}", rec.File);
    	foreach(var line in rec.Lines)
    	{
    		Console.Write("Address = {0} , Data = {1}", line.Address, line.Data);
    	}
    	
    }
