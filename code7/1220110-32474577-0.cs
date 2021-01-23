    public static string GetUserIpAddress()
    {
        HttpContext context = HttpContext.Current;
        try
        {
            return context.Request.UserHostAddress;
        }
        catch (Exception)
        {
            return "Unknown";
        }
    }
