    public static class UrlHelperExtensions
    {
        public static string AngularLink(this UrlHelper urlHelper, string url, RouteValueDictionary data)
        {
            return urlHelper.Link(url, data).Replace("api/", "#/");
        }
    }
