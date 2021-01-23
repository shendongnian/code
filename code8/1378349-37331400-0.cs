    public static void addReplaceCookie(string cookieName, string cookieValue, IHttpContextAccessor accessor)
    {
       //your code
    }
    public class CallerClass
    {
       private readonly IHttpContextAccessor _accessor;
       
       public CallerClass(IHttpContextAccessor accessor)
       {
           _accessor = accessor;
           addReplaceCookie(cookieName, cookieValue, accessor);
       }
    }
