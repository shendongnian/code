    public bool IsLoadedLowerThan(User other, ILocateTickets tickets)
    {
    	var load = CalculateLoad(tickets);
    	var otherLoad = other.CalculateLoad(tickets);
    	return load < otherLoad;
    }
    public int CalculateLoad(ILocateTickets tickets)
    {
    	return assignedTicketIds
    		.Select(id => tickets.GetById(id))
    		.Sum(ticket.CalculateLoad());
    }
