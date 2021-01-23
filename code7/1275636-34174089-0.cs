    public static int GetUserId(HttpContext context)
    {
        if(IsUserLoggedIn())
        {
            return Convert.ToInt16(context.Session["user"]);
        }
        return 0;
    }
