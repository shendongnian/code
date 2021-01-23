    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
        ticket.Version,
        userID,
        DateTime.Now,//ticket.IssueDate 
        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), 
        ticket.IsPersistent, 
        ticket.UserData, 
        ticket.CookiePath);
