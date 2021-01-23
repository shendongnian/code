    public async Task<bool> IsTokenValid(string jwtToken)
    {
    	JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
    
    	TokenValidationParameters validationParameters = new TokenValidationParameters
    	{
    		ValidAudience = audience,
    		ValidIssuer = issuer,
    		IssuerSigningTokens = signingTokens,
    		CertificateValidator = X509CertificateValidator.None
    	};
    
    	// Validate token.
    	SecurityToken validatedToken = new JwtSecurityToken();
    	ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);
    
    	// Set the ClaimsPrincipal on the current thread.
    	Thread.CurrentPrincipal = claimsPrincipal;
    
    	// Set the ClaimsPrincipal on HttpContext.Current if the app is running in web hosted environment.
    	if (HttpContext.Current != null)
    	{
    		HttpContext.Current.User = claimsPrincipal;
    	}
    
    	// If the token is scoped, verify that required permission is set in the scope claim.
    	if (ClaimsPrincipal.Current.FindFirst(scopeClaimType) != null && ClaimsPrincipal.Current.FindFirst(scopeClaimType).Value != "user_impersonation")
    		return await Task.FromResult(false);
    
    	return await Task.FromResult(true);
    }
