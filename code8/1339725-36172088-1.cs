    public bool ValidateToken(string token, byte[] secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
    
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningToken = new BinarySecretSecurityToken(secret)
        };
    
        SecurityToken validatedToken;
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
        catch (Exception)
        {
           return false;
        }
    
        return validatedToken != null;
    }
