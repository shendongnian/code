    UriBuilder url = new UriBuilder("mydomain.com/123456?qs=aaa&bg=bbb&pg=ccc");
    url.Path = string.Format("directory/{0}", url.Path);
    
    Uri formattedUrl = url.Uri;
    string queryString = formattedUrl.Query;
    // parse the query into a dictionary
    var parameters = HttpUtility.ParseQueryString(queryString);
    
    // get your parameters
    string qs = parameters.Get("qs");
    string bg = parameters.Get("bg");
    string pg = parameters.Get("pg");
