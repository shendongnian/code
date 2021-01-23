    var userName = "userName";
    var expiration = DateTime.Now.AddHours(3);
    var rememberMe = true;
    var ticketValueAsString = generateAdditionalTicketInfo(); // get additional data to include in the ticket
    var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, ticketValueAsString);
    var encryptedTicket = FormsAuthentication.Encrypt(ticket); // encrypt the ticket
    
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
    	{
    		HttpOnly = true,
    		Secure = true,
    	};
