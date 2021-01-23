    public class UserInfo
    {
        public String ip { get; private set; }
        public String browser { get; private set; }
        public String country { get; private set; }
        public UserInfo(HttpRequestBase Request)
        {
            ip = Request.UserHostAddress;
            browser = Request.Browser.Platform + " " + Request.Browser.Type + "/" + Request.Browser.Id + " " + Request.Browser.Version;
            country = "";
            if (Request.UserLanguages.Length > 0)
                country += " - " + Request.UserLanguages.ElementAt(0);
        }
    }
