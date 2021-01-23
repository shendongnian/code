    var tickets = new Dictionary<string, List<int>>()
    {
    	{ "TicketA", new List<int> { 1, 2, 3 } },
    	{ "TicketB", new List<int> { 3, 4, 1 } },
    	{ "TicketC", new List<int> { 5, 6, 7 } },
    	{ "TicketD", new List<int> { 7, 8, 5 } },
    	{ "TicketE", new List<int> { 9, 10, 11 } },
    	{ "TicketF", new List<int> { 11, 1, 9 } },
    };
    
    var newDict = new Dictionary<string, List<int>>(tickets);
    foreach(var ticket in newDict)
    {
    	bool madeChange = true;
    	while(madeChange)
    	{
    		var groupTickets = newDict.Where(t => t.Key != ticket.Key && t.Value.Intersect(ticket.Value).Any() && t.Value.Except(ticket.Value).Any()).ToList();
    		madeChange = false;
    		if (groupTickets.Any())
    		{
    			var newSet = groupTickets.SelectMany (t => t.Value).Union(ticket.Value).Distinct().ToList();				
    			ticket.Value.Clear();
    			ticket.Value.AddRange(newSet);
    			foreach(var groupTicket in groupTickets)
    			{
    				groupTicket.Value.Clear();
    				groupTicket.Value.AddRange(newSet);
    			}
    			madeChange = true;
    		}
    	}
    }
    
    newDict.GroupBy (t => String.Join(",", t.Value)).Dump();
