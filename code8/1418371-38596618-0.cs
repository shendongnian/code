            var contentFileServer = new FileServerOptions()
            {
                RequestPath = new PathString("/Content"),
                FileSystem = new PhysicalFileSystem(@"./Content"),
            };
            contentFileServer.StaticFileOptions.OnPrepareResponse = (context) => 
            {
                if (context.OwinContext.Authentication.User == null)
                {
                    // Reply an unauthorized
                    context.OwinContext.Response.StatusCode = 401;
                }
            };
            appBuilder.UseFileServer(contentFileServer);
