    public static bool Authenticate(HttpContext context)
        {
            if (!HttpContext.Current.Request.IsSecureConnection)
                return false;
            if (!HttpContext.Current.Request.Headers.AllKeys.Contains("Authorization"))
                return false;
            string authHeader = HttpContext.Current.Request.Headers["Authorization"];
            IPrincipal principal;
            if (TryGetPrincipal(authHeader, out principal))
            {
                HttpContext.Current.User = principal;
                return true;
            }
            return false;
        }
    private static bool TryGetPrincipal(string authHeader, out IPrincipal principal)
        {
            var creds = ParseAuthHeader(authHeader);
            if (creds != null && TryGetPrincipal(creds, out principal))
                return true;
            principal = null;
            return false;
        }
