    private Logn GLog(IHttpContextAccessor contextAccessor)
    {
        Ln Log = new LogInformation();
        Lg.IP = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        // ...
    }
