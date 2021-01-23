    public void Configuration(IAppBuilder app)
    {
        var tokenPath = new PathString("/Token"); //the same path defined in OAuthOptions.TokenEndpointPath
    
        app.Use(async (c, n) =>
        {
            //check if the request was for the token endpoint
            if (c.Request.Path == tokenPath)
            {
                var buffer = new MemoryStream();
                var body = c.Response.Body;
                c.Response.Body = buffer; // we'll buffer the response, so we may change it if needed
                await n.Invoke(); //invoke next middleware (auth)
                //check if we sent a SMS
                if (c.Get<bool>("sms_grant:sent"))
                {
                    var json = JsonConvert.SerializeObject(
                        new
                        {
                            message = "code send",
                            expires_in = 300
                        });
                    var bytes = Encoding.UTF8.GetBytes(json);
                    buffer.SetLength(0); //change the buffer
                    buffer.Write(bytes, 0, bytes.Length);
                    
                    //override the response headers
                    c.Response.StatusCode = 200;
                    c.Response.ContentType = "application/json";
                    c.Response.ContentLength = bytes.Length;
                }
                buffer.Position = 0; //reset position
                await buffer.CopyToAsync(body); //copy to real response stream
                c.Response.Body = body; //set again real stream to response body
            }
            else
            {
                await n.Invoke(); //normal behavior
            }
        });
    
        //other owin middlewares in the pipeline
        //ConfigureAuth(app);
    
        //app.UseWebApi( .. );
    }
