    public interface ICookieService {
        void AddReplaceCookie(string cookieName, string cookieValue);
    }
    
    public class CookieService : ICookieService {
        IHttpContextAccessor httpContextAccessor;
        public CookieService(IHttpContextAccessor httpContextAccessor) {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void AddReplaceCookie(string cookieName, string cookieValue) {
            var HttpContext = httpContextAccessor.HttpContext;
            if (HttpContext.Request.Cookies(cookieName) == null) {
                // add cookie
                HttpCookie s = new HttpCookie(cookieName);
                s.Value = cookieValue;
                s.Expires = DateTime.Now.AddDays(7);
                HttpContext.Response.Cookies.Add(s);
            } else {
                // ensure cookie value is correct 
                HttpCookie existingSchoolCookie = HttpContext.Request.Cookies(cookieName);
                existingSchoolCookie.Expires = DateTime.Now.AddDays(7);
                existingSchoolCookie.Value = cookieValue;
                HttpContext.Response.Cookies.Set(existingSchoolCookie);
            }
        }
    }
