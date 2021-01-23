            public void ProcessRequest(HttpContext context)
            {
                context.Response.ClearHeaders();
                string origin = context.Request.Headers["Origin"];
                context.Response.AppendHeader("Access-Control-Allow-Origin",
                    string.IsNullOrEmpty(origin) ? "*" : origin);
                string requestHeaders = context.Request.Headers["Access-Control-Request-Headers"];
                context.Response.AppendHeader("Access-Control-Allow-Headers",
                    string.IsNullOrEmpty(requestHeaders) ? "*" : requestHeaders);
                context.Response.AppendHeader("Access-Control-Allow-Methods", "POST, OPTIONS");
            }
