    public interface IWebUserContext
    {
        string Id { get; }
    }
    public class HttpWebUserContext : IWebUserContext
    {
        public string Id => HttpContext.Current.User.Identity.GetUserId();
    }
