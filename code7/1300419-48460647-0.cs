    // in some controller/handler, notice the "bare" Task return value
    public async Task LogoutAction()
    {
        // SomeOtherPage is where we redirect to after signout
        await MyCustomSignOut("/SomeOtherPage");
    }
    
    // probably in some utility service
    public async Task MyCustomSignOut(string redirectUri)
    {
        // inject the HttpContextAccessor to get "context"
        await context.SignOutAsync("Cookies");
        var prop = new AuthenticationProperties()
        {
            RedirectUri = redirectUri
        });
        // after signout this will redirect to your provided target
        await context.SignOutAsync("oidc", prop);
    }
