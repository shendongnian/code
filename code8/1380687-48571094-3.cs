    // TokenController.cs
    public IActionResult Some()
    {
        ...
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        Response.Cookies.Append(
            "x",
            tokenString,
            new CookieOptions()
            {
                Path = "/"
            }
        );
        return StatusCode(200, tokenString);
    }
    // JWTInHeaderMiddleware.cs
    public class JWTInHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public JWTInHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var name = "x";
            var cookie = context.Request.Cookies[name];
            if (cookie != null)
                if (!context.Request.Headers.ContainsKey("Authorization"))
                    context.Request.Headers.Append("Authorization", "Bearer " + cookie);
            await _next.Invoke(context);
        }
    }
    // Startup.cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseMiddleware<JWTInHeaderMiddleware>();
        ...
    }
