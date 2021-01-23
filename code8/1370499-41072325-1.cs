    if (arg == "User")
    {
        if (context.User.Identity.IsAuthenticated)
        { 
            return $"User={context.User.Identity.GetUserId()}";
        }
        else
        {
            return $"User={int.MinValue}";
        }
    }
