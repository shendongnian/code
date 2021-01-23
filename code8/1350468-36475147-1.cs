    public async Task<string> StoreTokenFromLogin(string user, string pass)
    {
        var token = await AuthLogin (user, pass);
        System.Diagnostics.Debug.WriteLine(token);
        System.Diagnostics.Debug.WriteLine(token.GetType ());
        return token; //should be a string
    }
