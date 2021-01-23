    String UserIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    if (string.IsNullOrEmpty(UserIP))
    {
        UserIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }
