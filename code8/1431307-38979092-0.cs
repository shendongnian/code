    public async Task Invoke(HttpContext context)
    {
        var authHeader = context.Request.Headers.Get("Authorization");
        if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
        {
            var token = authHeader.Substring("Basic ".Length).Trim();
            System.Console.WriteLine(token);
            var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialstring.Split(':');
            if(credentials[0] == "admin" && credentials[1] == "admin")
            {
                var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                var identity = new ClaimsIdentity(claims, "Basic");
                context.User = new ClaimsPrincipal(identity);
            }
        }
        else
        {
            context.Response.StatusCode = 401;
            context.Response.Headers.Set("WWW-Authenticate", "Basic realm=\"dotnetthoughts.net\"");
        }
        await _next(context);
    }
