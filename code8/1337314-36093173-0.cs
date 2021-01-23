    var userID = db.Users.Where(u => u.NTUserName == User.Identity.Name).Select(u => u.UserId).Single();
    var SubscribedIds = new HashSet<Guid>(db.TicketSubscriptions.Where(u => u.UserId == (userID)).Select(u => u.TicketId));
    var SubscribedList = db.Tickets
                  .Include(t => t.TicketNotes)
                  .Where(t => SubscribedIds.Contains(t.TicketId))
                                //.Where(t =>  (Properties.Settings.Default.ClosedID)
                  .OrderByDescending(t => t.TicketNumber)
                  .ToList();
    
    return View("SubscribedTickets", SubscribedList.ToPagedList(page, Properties.Settings.Default.PageSize));
