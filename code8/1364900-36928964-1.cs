    class HttpContextCurrentSessionIdProvider : ICurrentSessionIdProvider   
    {
         // Pull this from a constructor parameter or however you see fit.
         private readonly HttpContext _httpContext;
    
         public SessionId => _httpContext.Current.Session.SessionId;
    }  
