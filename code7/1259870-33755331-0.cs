    public static class Link
    {
        public static string RouteUrl(string routeName, object routeValues = null)
        {
            var url = String.Empty;
            try
            {
                var route = (Route)RouteTable.Routes[routeName];
                if (route == null)
                    return url;
    
                url = "~/".AbsoluteUrl() + route.Url;
                url = url.Replace("{culture}", System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower());
    
                if (routeValues == null) 
                    return url;
    
                var values =  routeValues.GetType().GetProperties();
                Array.ForEach(values, pi => url = Regex.Replace(url, "{" + pi.Name + "}", pi.GetValue(routeValues, null).ToString()));
    
                return url;
            }
            catch
            {
                var newUrl = RouteUrl("403");
                if(newUrl == String.Empty)
                    throw;
    
                return newUrl;
            }
        }
    
        public static string HttpRouteUrl(string routeName, object routeValues = null)
        {
           return RouteUrl(routeName, routeValues);
        }
    }
