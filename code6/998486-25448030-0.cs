    private static String GetWpLoginCookie(HttpContext context)
    {
    	String[] cookieKeys = context.Request.Cookies.AllKeys;
    	foreach (var cookieKey in cookieKeys)
    	{
    		if (cookieKey.StartsWith("wordpress_logged_in"))
    		{
    			return WebUtility.UrlDecode(context.Request.Cookies[cookieKey].Value);
    		}
    	}
    	return "Not found";
    }
