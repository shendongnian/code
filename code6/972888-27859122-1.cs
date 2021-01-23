    public string Get()
    {
        if(User.IsInRole("admin"))
        {
            return "Text for admin";
        }
        if(User.IsInRole("user"))
        {
            return "Text for user";
        }
    }
