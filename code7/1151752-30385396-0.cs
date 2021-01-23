    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket( 
      userName,
      DateTime.Now,
      DateTime.Now.AddMinutes(50),
      rememberUserName,
      roles + "@@@@" + userId, //<-******** This Line Changes ********
      FormsAuthentication.FormsCookiePath);
    //... then in Application_AuthenticateRequest() do something like this:
    var userData = ticket.UserData.Split(new string[]{"@@@@"}, StringSplitOptions.RemoveEmptyEntries);
    var userIdAsString = userData[1];
    var roles = userData[0].Split( new char[]{ ',' } ); 
