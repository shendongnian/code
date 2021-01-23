    public static IApplicationBuilder CustomCookieAuthentication(this IApplicationBuilder application, string url)
    {
        if (application == null)
            throw new ArgumentNullException(nameof(application));
    
        if (url == null)
            throw new ArgumentNullException(nameof(url));
    
        IApplicationBuilder chain = application.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            CookieName = SecurityExtensions.CookieName,
            CookieHttpOnly = true,
            CookieSecure = Configuration.Authentication.Cookie.Secure,
            ExpireTimeSpan = TimeSpan.FromDays(30),
            SlidingExpiration = true,
            AutomaticAuthenticate = true,
            AutomaticChallenge = true,
            LoginPath = new PathString(url),
            AccessDeniedPath = new PathString(url)
        });
    
        return chain;
    }
    public static async Task Login(this HttpContext context, string username, Unique accountId, bool persistent)
    {
        await context.Logout();
    
        Claim id = new Claim(ClaimTypes.UserData, accountId.ToString());
        Claim version = new Claim(ClaimTypes.Version, SecurityExtensions.Version.ToString());
        ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { id, version }, SecurityExtensions.CookieName));
    
        DateTime utc = DateTime.UtcNow;
    
        AuthenticationProperties properties = new AuthenticationProperties();
        properties.IssuedUtc = utc;
        properties.IsPersistent = persistent;
    
        if (persistent == true)
            properties.ExpiresUtc = utc.AddYears(1);
    
        await context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
    }
    public static async Task Logout(this HttpContext context)
    {
        await context.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    
        ISession session = SecurityExtensions.GetSession(context);
        session?.Clear();
    }
