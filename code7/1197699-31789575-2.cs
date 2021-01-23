    public static void VerifyUserIsAuthenticated()
    {
        if(!HttpContext.Current.Request.IsAuthenticated)
        {
            Response.StatusCode = 401;
            Response.End();
        }
    }
