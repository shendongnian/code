     if (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
     {
        var builder = new UriBuilder(Request.Url) { Host = "www." + Request.Url.Host };
        Response.StatusCode = 301;
        Response.AddHeader("Location", builder.ToString());
        Response.End();
     }
