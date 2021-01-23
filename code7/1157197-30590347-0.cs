    public static class CookieValues
    {
        public static void test(HttpResponseBase resp, HttpRequestBase request, HttpResponseBase response)
        {
            Set("Test", "123", request, response);
            Set("Name", "Nick", request, response);
            Set("Sex", "male", request, response);
            var x = Get("Test", request);
        }
        public static void Set(string key, string value, HttpRequestBase request, HttpResponseBase response)
        {
            HttpCookie cookie = GetCookie(request);
            cookie[key] = value;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.Cookies.Add(cookie);
        }
        public static string Get(string key, HttpRequestBase request)
        {
            HttpCookie cookie = GetCookie(request);
            if (cookie[key] != null)
            {
                return cookie[key];
            }
            return "";
        }
        private static HttpCookie GetCookie(HttpRequestBase request)
        {
            HttpCookie cookie = request.Cookies["HolidayAdmin"];
            if (cookie == null)
            {
                cookie = new HttpCookie("HolidayAdmin");
                request.Cookies.Add(cookie);
            }
            return cookie;
        }
    }
