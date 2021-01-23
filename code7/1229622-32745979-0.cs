           FormsIdentity id = (FormsIdentity)User.Identity;
           FormsAuthenticationTicket ticket = id.Ticket;
           
           //those are label ids, that why they have Text property 
           cookiePath.Text = ticket.CookiePath;
           expireDate.Text = ticket.Expiration.ToString();
           expired.Text = ticket.Expired.ToString();
           isPersistent.Text = ticket.IsPersistent.ToString();
           issueDate.Text = ticket.IssueDate.ToString();
           name.Text = ticket.Name;
           userData.Text = ticket.UserData; // string userData you passed is HERE
           version.Text = ticket.Version.ToString();
