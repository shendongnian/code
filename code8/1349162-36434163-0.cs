    public static string GetValue(string key)
    {
        DeveloperDetails dd;
        if ( details.TryGetValue(key, out dd) )
        {
            return dd.ClientID;  //or dd.DeveloperToken
        }
        else
        {
            return null;
        }
    }
