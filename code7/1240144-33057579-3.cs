    public Authenticator()
    {
        var logins = File.ReadAllLines(@"C:\YourDirectory\users.csv");
        foreach(var login in logins)
        {
            var parts = login.Split(',');
            Credentials.Add(parts[0].Trim(), parts[1].Trim());
        }
    }
