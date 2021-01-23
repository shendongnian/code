    public async Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
    {
        // your code here 
        context.Request.Properties["MyDataKey"] = new List<string> { "from my properties" };
    }
