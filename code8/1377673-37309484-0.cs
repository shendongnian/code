    private static bool isMvc(HttpContext ctx)
    {
        bool retVal = false;
        string []header = ctx.Request.Headers.AllKeys;
        if (header.Contains("X-AspNetMvc"))
        {
            retVal = true;
        }
    return retVal;
}
