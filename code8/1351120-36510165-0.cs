    protected override async Task<bool> HandleForbiddenAsync(ChallengeContext context)
    {
        var properties = new AuthenticationProperties(context.Properties);
        var returnUrl = properties.RedirectUri;
        if (string.IsNullOrEmpty(returnUrl))
        {
            returnUrl = OriginalPathBase + Request.Path + Request.QueryString;
        }
        var accessDeniedUri = Options.AccessDeniedPath + QueryString.Create(Options.ReturnUrlParameter, returnUrl);
        var redirectContext = new CookieRedirectContext(Context, Options, BuildRedirectUri(accessDeniedUri), properties);
        await Options.Events.RedirectToAccessDenied(redirectContext);
        return true;
    }
