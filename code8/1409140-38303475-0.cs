    static void Main(string[] args)
    {
        bool test = Test("http://myUrl.com/rollcontainer-Wei&ß", "http://myUrl.com/rollcontainer-wei&amp;&szlig;");
    }
    public static bool Test(string url1, string url2)
    {
        Uri uri1 = new Uri(HttpUtility.HtmlDecode(url1)); 
        Uri uri2 = new Uri(HttpUtility.HtmlDecode(url2));
        var result = Uri.Compare(uri1, uri2,
            UriComponents.Host | UriComponents.PathAndQuery,
            UriFormat.Unescaped, StringComparison.OrdinalIgnoreCase);
        return result == 0;
    }
