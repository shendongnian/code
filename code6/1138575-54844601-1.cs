public static string AddOrReplaceQueryParameter(this HttpContext c, params string[] nameValues)
    {
        if (nameValues.Length%2!=0)
        {
            throw new Exception("nameValues: has more parameters then values or more values then parameters");
        }
        var qps = new Dictionary<string, StringValues>();
        for (int i = 0; i < nameValues.Length/2; i++)
        {
            qps.Add(nameValues[i], nameValues[i + 1]);
        }
        return c.AddOrReplaceQueryParameters(qps);
    }
public static string AddOrReplaceQueryParameters(this HttpContext c, Dictionary<string,StringValues> pvs)
    {
        var request = c.Request;
        UriBuilder uriBuilder = new UriBuilder
        {
            Scheme = request.Scheme,
            Host = request.Host.Host,
            Port = request.Host.Port ?? 0,
            Path = request.Path.ToString(),
            Query = request.QueryString.ToString()
        };
        var queryParams = QueryHelpers.ParseQuery(uriBuilder.Query);
        
        foreach (var (p,v) in pvs)
        {
            queryParams.Remove(p);
            queryParams.Add(p, v);
        }
        uriBuilder.Query = "";
        var allQPs = queryParams.ToDictionary(k => k.Key, k => k.Value.ToString());
        var url = QueryHelpers.AddQueryString(uriBuilder.ToString(),allQPs);
        return url;
    }
Next and prev links for example in a view:
var next = Context.Request.HttpContext.AddOrReplaceQueryParameter("page",Model.PageIndex+1+"");
var prev = Context.Request.HttpContext.AddOrReplaceQueryParameter("page",Model.PageIndex-1+"");
