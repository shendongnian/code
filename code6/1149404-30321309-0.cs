    var token = GetQueryParameter(0); // Get first query parameter
    var entry = TokenTable.Element(e => e.Token == token);
    TokenTable.Remove(entry);
    if (DateTime.Now > entry.Expires)
    {
       // Their token has expired
       GoTo("TokenExpired.aspx");
       return;
    }
    LoginController.UserLoggedIn(entry.Id);
