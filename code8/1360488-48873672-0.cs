    app.Use(async (context, next) =>
                    {
                        if (!context.User.Identity.IsAuthenticated && context.Request.Path.StartsWithSegments("/excelfiles"))
                        {
                            throw new Exception("Not authenticated");
                        }
                        await next.Invoke();
                    });
