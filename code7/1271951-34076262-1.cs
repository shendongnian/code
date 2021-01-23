        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var pathAndQuery = System.Web.HttpUtility.UrlDecode(Request.Url.PathAndQuery);
            if (pathAndQuery == null || Regex.IsMatch(pathAndQuery, @"^.*\.(axd|css|js|jpg|jpeg|png|gif|txt|xml|svg|pdf)$"))
            {
                return;
            }
            if (Regex.IsMatch(pathAndQuery, ".*[A-Z].*"))
            {
                Response.Redirect(pathAndQuery.ToLower(), false);
                Response.StatusCode = 301;
            }
        }
