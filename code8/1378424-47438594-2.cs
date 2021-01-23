    public static bool ValidateCredentials(string userName, string password)
    {
        try 
        {
            using (var adContext = new PrincipalContext(ContextType.Domain, "YOUR_AD_DOMAIN"))
            {
                return adContext.ValidateCredentials(userName, password);
            }
        }
        catch(Exception ex) 
        {
            throw ex;
        }
    }
