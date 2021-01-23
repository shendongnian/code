            var ticketId=db.Tickets.FirstOrDefault(t =>t.TicketNumber==ticketNumber).TicketId;
            varuserId=db.Users.FirstOrDefault(u=>u.NTUserName.Equals(User.Identity.Name)).UserId;
            
            if(ticketId != null && userId != null)
            {
            
                  bool subscriptionExists = db.TicketSubscriptions.
                                      Any(ts => ts.TicketId.Equals(ticketId) && ts.UserId == userId)
            }
