    public class AuthorizationHeader
    {
        private readonly RequestDelegate _next;
    
        public AuthorizationHeader(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            var authenticationCookieName = "exampleToken";
            var cookie = context.Request.Cookies[authenticationCookieName];
            if (cookie != null)
            {
    
                if (!context.Request.Path.ToString().ToLower().Contains("/account/logout"))
                {
                    if (!string.IsNullOrEmpty(cookie))
                    {
                        var token = JsonConvert.DeserializeObject<AccessToken>(cookie);
                        if (token != null)
                        {
                            var headerValue = "Bearer " + token.access_token;
                            if (context.Request.Headers.ContainsKey("Authorization"))
                            {
                                context.Request.Headers["Authorization"] = headerValue;
                            }else
                            {
                                context.Request.Headers.Append("Authorization", headerValue);
                            }
                        }
                    }
                    await _next.Invoke(context);
                }
                else
                {
                    // this is a logout request, clear the cookie by making it expire now
                    context.Response.Cookies.Append(authenticationCookieName,
                                                    "",
                                                    new Microsoft.AspNetCore.Http.CookieOptions()
                                                    {
                                                        Path = "/",
                                                        HttpOnly = true,
                                                        Secure = false,
                                                        Expires = DateTime.UtcNow.AddHours(-1)
                                                    });
                    context.Response.Redirect("/");
                    return;
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
