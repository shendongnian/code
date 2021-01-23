            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    if (!context.Context.User.Identity.IsAuthenticated && context.Context.Request.Path.StartsWithSegments("/excelfiles"))
                    {
                        throw new Exception("Not authenticated");
                    }
                }
            });
