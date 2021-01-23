    public void AssignTicket(Ticket ticket)
    {
        if(ticketIds.Contains(ticket.Id)) return;
        
        Publish(new TicketAssignedToUser
            {
                UserId = id,
                Ticket = new TicketLoad
                    {
                        Id = ticket.Id,
                        Load = ticket.CalculateLoad() 
                    }
            });
    }
    public void When(TicketAssignedToUser e)
    {
        ticketIds.Add(e.Ticket.Id);
        totalLoad += e.Ticket.Load;
    }
