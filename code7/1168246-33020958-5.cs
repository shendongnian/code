    public bool IsLoadedLowerThan(User other, Repository repository)
    {
    	var load = CalculateLoad(repository);
    	var otherLoad = other.CalculateLoad(repository);
    	
    	return load < otherLoad ? this : other;
    }
    
    public int CalculateLoad(Repository repository)
    {
    	return assignedTicketIds
    		.Select(id => repository.Get<Ticket>(id))
    		.Sum(ticket.CalculateLoad());
    }
