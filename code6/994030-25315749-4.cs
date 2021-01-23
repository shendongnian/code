    lines.AddRange(File.ReadAllLines(@"test.txt"));
    var clients = new List<Clients>();
    
    foreach (var lineToSplit in lines)
    {
    	var split = lineToSplit.Split(',');
    	clients.Add(new Clients
    	{
    		ClientName = split[0]
    		//etc
    	});
    }
