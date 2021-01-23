    FormsAuthenticationTicket ticket = null;
    ticket = new FormsAuthenticationTicket(1, lg.UserName, DateTime.Now, 
            DateTime.Now.AddMinutes(50), ckbRemember.Checked,
            email + "," + column1 + ","+ column2 + "," + type);
    //or just use line of code below after creating ticket object
    //ticket.UserData = email + "," + column1 + ","+ column2 + "," + type;
