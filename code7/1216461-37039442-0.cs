     public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.IsTokenEndpoint && context.Request.Method == "OPTIONS")
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { ConfigurationManager.AppSettings["allowedOrigin"]});
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Authorization","Cache-Control","Pragma" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });
                context.MatchesTokenEndpoint();
                context.RequestCompleted();
            }
            if (context.IsAuthorizeEndpoint && context.Request.Method == "OPTIONS")
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { ConfigurationManager.AppSettings["allowedOrigin"]});
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Authorization", "Cache-Control", "Pragma" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });
                context.MatchesAuthorizeEndpoint();
                context.RequestCompleted();
            }
           
            return base.MatchEndpoint(context);
        }
