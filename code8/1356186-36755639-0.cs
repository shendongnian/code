    public void Configuration(IAppBuilder app)
    {
        var tokenPath = new PathString("/Token"); //the same path defined in OAuthOptions.TokenEndpointPath
    
        app.Use(async (c, n) =>
        {
            await n.Invoke(); //invoke next middleware (auth)
    
            //check if the request was for the token endpoint
            if (c.Request.Path == tokenPath)
            {
                //check if we sent a SMS
                if (c.Get<bool>("sms_grant:sent"))
                {
                    //override the response
                    c.Response.StatusCode = 200;
                    c.Response.ContentType = "application/json";
                    c.Response.Write(JsonConvert.SerializeObject(
                        new
                        {
                            message = "code send",
                            expires_in = 300
                        }));
                }
            }
        });
    
        //other owin middlewares in the pipeline
        //ConfigureAuth(app);
    
        //app.UseWebApi( .. );
    }
