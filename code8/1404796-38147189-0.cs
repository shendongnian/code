    public static class CustomHtmlHelpers 
    {
       public static string UrlEncode(string url)
       {
           return url.Replace(" ", "+");
       }
    }
