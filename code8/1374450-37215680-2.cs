      private string GetUserEmail(AuthenticationContext context, string clientId)
    {
        // ADAL caches the ID token in its token cache by the client ID
        foreach (TokenCacheItem item in context.TokenCache.ReadItems())
        {
            if (item.Scope.Contains(clientId))
            {
                return GetEmailFromIdToken(item.Token);
            }
        }
        return string.Empty;
    }
        private string GetEmailFromIdToken(string token)
    {
        // JWT is made of three parts, separated by a '.' 
        // First part is the header 
        // Second part is the token 
        // Third part is the signature 
        string[] tokenParts = token.Split('.');
        if (tokenParts.Length < 3)
        {
            // Invalid token, return empty
        }
        // Token content is in the second part, in urlsafe base64
        string encodedToken = tokenParts[1];
        // Convert from urlsafe and add padding if needed
        int leftovers = encodedToken.Length % 4;
        if (leftovers == 2)
        {
            encodedToken += "==";
        }
        else if (leftovers == 3)
        {
            encodedToken += "=";
        }
        encodedToken = encodedToken.Replace('-', '+').Replace('_', '/');
        // Decode the string
        var base64EncodedBytes = System.Convert.FromBase64String(encodedToken);
        string decodedToken = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        // Load the decoded JSON into a dynamic object
        dynamic jwt = Newtonsoft.Json.JsonConvert.DeserializeObject(decodedToken);
        // User's email is in the preferred_username field
        return jwt.preferred_username;
    }
