    public class ApiKeyAuthenticationAttribute : IAuthenticationFilter
    {
    	public bool AllowMultiple { get; set; }
    
    	public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    	{
    		HttpRequestMessage request = context.Request;
    
    		// Get Auth header
    		AuthenticationHeaderValue authorization = request.Headers.Authorization;
    
    		// Validate the static token
    		if (authorization?.Parameter == "123")
    		{
    			IPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { new Claim("CLAIMTYPE", "CLAIMVALUE") }));
    
    			context.Principal = principal;
    		}
    		else
    		{
    			context.ErrorResult = new AuthenticationFailureResult(request);
    		}
    	}
    
    	public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    	{
    		var challenge = new AuthenticationHeaderValue("Basic");
    		context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
    
    		return Task.FromResult(0);
    	}
    }
