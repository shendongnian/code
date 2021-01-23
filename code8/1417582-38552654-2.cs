    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom.Equals("Session", StringComparison.InvariantCultureIgnoreCase))
        {
            // make sure that the session value is convertible to string
            return (string)context.Session["Here you put your session Id"];
        }
        return base.GetVaryByCustomString(context, custom);
    }
