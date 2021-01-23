    protected void Application_BeginRequest(object sender, EventArgs e)
            {
                var app = (HttpApplication)sender;
                string path = app.Context.Request.Url.PathAndQuery;
                int pos = path.IndexOf("?");
                if (pos > -1)
                {
                    string[] array = path.Split('?');
                    app.Context.RewritePath(array[0]+"?"+ HttpContext.Current.Server.UrlDecode(array[1]));
                }
            }
