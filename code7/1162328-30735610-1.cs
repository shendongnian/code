    [ServiceBehavior(Namespace = QuickBooks.URL)]
    public class QuickBooks : IQuickBooks
    {
    	public const string URL = "http://developer.intuit.com/";
    
    	public AuthenticateResponse authenticate(Authenticate authenticateSoapIn)
    	{
    		// Check if authenticateSoapIn is valid
    
    		var authenticateResponse = new AuthenticateResponse();
    		authenticateResponse.AuthenticateResult.Add(System.Guid.NewGuid().ToString());
    		authenticateResponse.AuthenticateResult.Add(string.Empty);
    
    		return authenticateResponse;
    	}
    }
