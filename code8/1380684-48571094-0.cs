    // TokenController.cs
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get([FromQuery]string username, [FromQuery]string password)
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
            var name = "ged";
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
        app.UseMiddleware<JWTInHeaderMiddleware>();
    }
