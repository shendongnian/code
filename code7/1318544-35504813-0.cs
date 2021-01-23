    protected void Application_BeginRequest(object sender, EventArgs e)
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:14576");
                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
    
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Authorization-Token, X-HTTP-Method-Override");
                    HttpContext.Current.Response.End();
                }
            }
