    public StoredAccountInfo RefreshAccountData(string username = null, string password = null)
    {
        username = username ?? _username;
        password = password ?? _password;
        if ((string.IsNullOrEmpty(username)) || 
            (string.IsNullOrEmpty(password))
        {
            //throw Exception("Password Or Username Not Set");
        }
