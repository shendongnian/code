    public static string ModifyQueryString(this UrlHelper helper, string url, NameValueCollection updates, IEnumerable<string> removes)
    {
        NameValueCollection query;
        var request = helper.RequestContext.HttpContext.Request;
        if (string.IsNullOrWhiteSpace(url))
        {
            url = request.Url.AbsolutePath;
            query = HttpUtility.ParseQueryString(request.QueryString.ToString());
        }
        else
        {
            var urlParts = url.Split('?');
            url = urlParts[0];
            if (urlParts.Length > 1)
            {
                query = HttpUtility.ParseQueryString(urlParts[1]);
            }
            else
            {
                query = new NameValueCollection();
            }
        }
        updates = updates ?? new NameValueCollection();
        foreach (string key in updates.Keys)
        {
            query.Set(key, updates[key]);
        }
        removes = removes ?? new List<string>();
        foreach (string param in removes)
        {
            query.Remove(param);
        }
        if (query.HasKeys())
        {
            return string.Format("{0}?{1}", url, query.ToString());
        }
        else
        {
            return url;
        }
    }
