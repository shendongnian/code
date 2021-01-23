     public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.IsTokenEndpoint && context.Request.Method == "OPTIONS")
            {
                if (!context.OwinContext.Response.Headers.Keys.Contains("Access-Control-Allow-Origin"))
                    context.OwinContext.Response.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Origin", new[] { ConfigurationManager.AppSettings["allowedOrigin"] });
                if (!context.OwinContext.Response.Headers.Keys.Contains("Access-Control-Allow-Headers"))
                    context.OwinContext.Response.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Headers", new[] { "Accept", "Content-Type", "Authorization", "Cache-Control", "Pragma", "Origin" });
                if (!context.OwinContext.Response.Headers.Keys.Contains("Access-Control-Allow-Methods"))
                    context.OwinContext.Response.Headers.AppendCommaSeparatedValues("Access-Control-Allow-Methods", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });
                context.MatchesTokenEndpoint();
                context.RequestCompleted();
                return Task.FromResult<object>(null);
            }
            
            return base.MatchEndpoint(context);
        }
