    protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE,OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "X-Requested-With,Content-Type");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.End();
            }
        }
