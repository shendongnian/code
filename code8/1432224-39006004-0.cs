    public static void GetAccessTokenNonAsync()
    {
    	// Call the async method and get the resulting task.
    	Task<AuthenticationResult> accessTokenTask = GetAccessToken();
    	// Wait for the task to finish.
    	accessTokenTask.Wait();
    }
    
    private async static Task<AuthenticationResult> GetAccessToken()
    {
    	return await Task.Factory.StartNew<AuthenticationResult>
    	(
    		() =>
    		{
    			// Insert code here.
    			return new AuthenticationResult();
    		}
    	);
    }
