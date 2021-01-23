    public string ToQueryString(this IDictionary dict)
        {
        string querystring="";
        foreach(string key in dict.AllKeys)
            {
            querystring += key + "=" + dict[key] + "&";
            }
        return querystring;
        }
