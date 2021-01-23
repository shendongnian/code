    public void SomeMethod()
    {
        string requestUrl = HttpContext.Current.Request.Url.ToString();
        string sCookie = string.Format("{0}", HttpContext.Current.Request.Headers["cookie"]);
        Parallel.For(0, 100, i =>
        {
            var data = GetDataFor(i,
        requestUrl: requestUrl,
        sCookie: sCookie);
        });
    }
    public data GetDataFor(int i, string requestUrl = null, string sCookie = null)
    {
        Uri requestUri = null;
        if (HttpContext.Current != null)
        {
            requestUri = HttpContext.Current.Request.Url;
            sCookie = string.Format("{0}", HttpContext.Current.Request.Headers["cookie"]);
        }
        else
        {
            requestUri = new Uri(requestUrl);
        }
        return data;
    }
