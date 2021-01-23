    public string ToQueryString(this NameValueCollection qs)
    {
        string querystring="";
        foreach(string key in qs.AllKeys)
            {
            querystring += key + "=" + qs[key] + "&";
            }
        return querystring;
    }
