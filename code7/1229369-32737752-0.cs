        public static string GetAdvancedCookieValue(UrlHelper url, string cookieName)
        {
            var request = url.RequestContext.HttpContext.Request;
            var response = url.RequestContext.HttpContext.Response;
            if (response.Cookies[cookieName] != null)
            {
                if (response.Cookies[cookieName].Value == null)
                    response.Cookies.Remove(cookieName);
                else
                    return response.Cookies[cookieName].Value;
            }
            if (request.Cookies[cookieName] != null && String.IsNullOrWhiteSpace(request.Cookies[cookieName].Value) == false)
                return request.Cookies[cookieName].Value;
            return null;
        }
