    app.Map("/login", map =>
                {
                    map.Run(async ctx =>
                    {
                        if (ctx.Authentication.User == null ||
                            !ctx.Authentication.User.Identity.IsAuthenticated)
                        {
                            ctx.Response.StatusCode = 401;
                        }
                        else
                        {
                            ctx.Response.Redirect("/");
                        }
                    });
                });
    app.Run(async ctx =>
                {
                    var user = ctx.Authentication.User;
                    var response = ctx.Response;
    
                    response.ContentType = "text/html";
    
                    if (user != null && user.Identity.IsAuthenticated)
                    {
                        await response.WriteAsync(string.Format("<h2>{0}</h2>",
                            user.Claims.First().Issuer));
    
                        await response.WriteAsync("<dl>");
                        foreach (var claim in user.Claims)
                        {
                            await response.WriteAsync(string.Format(
                                "<dt>{0}</dt> <dd>{1}</dd>",
                                claim.Type,
                                claim.Value));
                        }
                        await response.WriteAsync("</dl>");
                    }
                    else
                    {
                        await ctx.Response.WriteAsync("<h2>anonymous</h2>");
                    }
                });
