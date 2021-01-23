    public override string GetVaryByCustomString(HttpContext context, string arg) 
    { 
        if(arg.ToLower() == "user") 
        { 
            if (context.User.Identity.IsAuthenticated())
            {
                return context.User.Identity.Name;
            }
            return null;
        } 
    
        return base.GetVaryByCustomString(context, arg); 
    }
