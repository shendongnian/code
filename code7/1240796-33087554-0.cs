    public const string SelfIssue = "Self-Issue";
    public void Configuration(IAppBuilder app)
    {
        app.SetDefaultSignInAsAuthenticationType(SelfIssue);
        app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = SelfIssue });
    }
