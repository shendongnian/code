    public interface ICookieFactory 
    {
        Cookie BakeCookie(); 
    }
    public class ChocolateChipCookieFactory : ICookieFactory
    {
        public Cookie BakeCookie()
        {
            return new ChocolateChipCookie();
        }
    }
    public abstract class Cookie
    {
        public abstract IEnumerable<Crumb> Crumble();
    }
    public class ChocolateChipCookie : Cookie
    {
        public override IEnumerable<Crumb> Crumble()
        {
            ...
        }
    }
    ICookieFactory factory = new ChocolateChipCookieFactory();
    Cookie cookie = factory.BakeCookie();
    foreach (Crumb crumb in cookie.Crumble())
    {
        ...
    }
