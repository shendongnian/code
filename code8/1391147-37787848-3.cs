    var dbResult = from ticket in ticketsCollection.AsQueryable()
                   where ticket.TicketProjectID == 49
                   select new 
                   {
                       TicketProjectID = ticket.TicketProjectID,
                       TicketID = ticket.TicketID,
                       ConcatValue = ticket.Status + " - " + ticket.Name
                   };
