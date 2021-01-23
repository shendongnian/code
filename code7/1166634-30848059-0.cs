    public string IsAuthenticUser(string userId, string password)
    {
        return System.Configuration.ConfigurationManager.AppSettings["authenticUsers"]
            .Split(',')
            .Select(token => token.Split(new[]{"=>"},StringSplitOptions.None))
            .Select(arr => new {  
                Username = arr[0].Split(':')[0], 
                Password = arr[0].Split(':').Last(), 
                Role     = arr.Last()
            })
            .Where(x => x.Username == userId && x.Password == password)
            .Select(x => x.Role)
            .DefaultIfEmpty(null)
            .First();
    }
