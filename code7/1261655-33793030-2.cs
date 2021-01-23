                    else if (context.Request.Path.Value == "/Auth/")
                {
                    if (context.Authentication.User != null)
                        context.Response.Redirect(BLL._Configuration.HinagGameURL);
                    
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(_Authpage);
                }
