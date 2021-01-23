        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Add CORS headers to allow a JavaScript client to call the WCF service via AJAX from a different domain
            var requestOrigin = Request.Headers.Get("Origin");
            Log.Debug($"Processing request from Origin: '{requestOrigin}'");
            
            // Accommodate for all possible cross-domain requests
            if (string.IsNullOrEmpty(requestOrigin) == false)
            {
                if (requestOrigin.Contains("devdomain"))
                {
                    AddAllowedOrigin("http://devdomain");
                }
                else if (requestOrigin.Contains("qasdomain"))
                {
                    AddAllowedOrigin("http://qasdomain");
                }
                else if (requestOrigin.Contains("prddomain"))
                {
                    AddAllowedOrigin("http://prddomain");
                }
            }
            // Respond to an OPTIONS pre-flight request
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
        private static void AddAllowedOrigin(string origin)
        {
            Log.Debug($"Adding Access-Control-Allow-Origin header to response to allow Origin: '{origin}'");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
        }
