    var ticketId=db.Tickets.FirstOrDefault(t =>t.TicketNumber==ticketNumber).TicketId;
    var userId=db.Users.FirstOrDefault(u=>u.NTUserName.Equals(User.Identity.Name)).UserId;
    
    bool subscriptionExists = db.TicketSubscriptions.
                              Any(ts => ts.TicketId.Equals(ticketId) && ts.UserId == userId);
