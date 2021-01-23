        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();
                app.Use(async (context, next) =>
                {
                    var content = context.Request.Body;
                    if (content == Stream.Null)
                    {
                       await next();
                    }
                    else
                    {
                        using (var stream = new MemoryStream())
                        {
                            await content.CopyToAsync(stream);
                            stream.Position = 0;
                            context.Request.Body = stream;
                            await next();
                        }
                      
                        context.Request.Body = content;
                    }
                });
                app.UseWebApi(config);        
            }
        }
