    public class UserProvider : ICurrentUser {
        HttoContextBase httpContext;
        UserProvider(){
            httpContext = HttpContext.Current;
        }
        public string Name { 
            get{ return httpContext?.User?.Identity?.Name ?? string.Empty; } 
        }
    }
