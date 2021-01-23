    from ticket in tblTickets
    join user in tblUsers on ticket.CreatedBy equals user.UserId
    join userAssigned in tblUsers on ticket.AssignTo equals userAssigned.UserId into temp 
    from userAssignedLeft in temp.DefaultIfEmpty()
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
           UsernameCreatedBy = user.Username,
           UsernameAssigned = userAssignedLeft.Username
    }    
