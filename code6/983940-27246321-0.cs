    protected override void OnStartProcessingRequest(ProcessRequestArgs args)
    {
        var user = HttpContext.Current.User;
        // Only Administrator users are allowed access
        if (!user.IsInRole("Administrator"))
        {
            // Any other role throws a security exception
            throw new SecurityException("You do not have permission to access this Service");
        }
        base.OnStartProcessingRequest(args);
    }
