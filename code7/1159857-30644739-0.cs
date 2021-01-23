    public List<Ticket> GetTickets(Status? status,Priority? priority,TicketLevel? ticketLevel, DateTime? createdOn,DateTime? modifiedOn,bool? removed)
    {
    	using (CRMContext context=new CRMContext())
        {
        	var query = context.Tickets.Select(t => t);
    		
    		if(status != null)
    			query = query.Where(t => t.Status == status);
    			
    		if(priority != null)
    			query = query.Where(t => t.Priority == priority);
    		
    		if(ticketLevel != null)
    			query = query.Where(t => t.TicketLevel == ticketLevel);
    		
    		//.... More conditions...
    		
    		return query.ToList();
    	}
    }
