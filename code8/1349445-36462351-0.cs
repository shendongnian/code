			app.Use(next => async context => {
                        
                         // get the frame from kestrel and then but the path by removing the hostname 
                        var Frame = (Microsoft.AspNet.Server.Kestrel.Http.Frame)context.Features;
                        var newpath = Frame.RequestUri.Replace("http://" + context.Request.Host.Value, "");
                        context.Request.Path = newpath;
                        // Invoke the rest of the pipeline.
                        await next(context);
                
            });
