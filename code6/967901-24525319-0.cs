    public UserData ByPassword(string emailAddress, string password) {
        // null-check your arguments to detect programming errors in the "upstream" code
        if (emailAddress == null) throw new ArgumentNullException("emailAddress");
        if (password == null) throw new ArgumentNullException("password");
        // Now that your arguments are "sanitized", fix the Single() call
        Account account = db.Accounts.Where(acc => acc.AccMail == emailAddress && acc.AccPassword == password.ToLower()).SingleOrDefault();
        // Missing credentials is not a programming error - throw your specific exception here:
        if (account == null) {
            throw new OurException(OurExceptionType.InvalidCredentials);
        }
        string token = OurAuthorizationAttribute.CreateTicket(account.AccID, false);
        UserData data = new UserData();
        data.Id = account.AccID;
        data.Token = token;
        return data;
    }
