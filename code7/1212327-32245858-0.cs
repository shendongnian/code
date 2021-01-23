    from ticket in tblTickets
    join user in tblUsers on ticket.CreatedBy equals user.UserId into temp 
    from userLeft in temp.DefaultIfEmpty()
    select new
    {
       ticket.TicketId,
       ticket.Subject,
       ticket.Issue,
       ticket.Priority,
       ticket.StatusId,
       ticket.Attachment,
       ticket.CreatedDate,
       ticket.ModifiedDate,
       ticket.Comment,
      (userLeft == null ? String.Empty : userLeft.Username)
    }
