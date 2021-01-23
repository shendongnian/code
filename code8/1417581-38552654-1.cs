    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom.Equals("User", StringComparison.InvariantCultureIgnoreCase))
        {
            // Return the user name/login as a value that will invalidate cache per authenticated user. 
            return context.User.Identity.Name;
        }
        return base.GetVaryByCustomString(context, custom);
    }
