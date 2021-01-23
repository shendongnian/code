    public async Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
    {
        // your code here 
        HttpContext.Current.Items["MyDataKey"] = new List<string> { "from my items" };
    }
