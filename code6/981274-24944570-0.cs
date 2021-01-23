    public class CookieService : ICookieService
    {
      public int GetCurrentUserId()
      {
        //pseudo code
        return HttpContext.Current.GetCookie["UserId"];
      }
    }
