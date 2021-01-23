    using System.Web;
    public class BrowserInfo
    {
        public BrowserInfo(HttpRequestBase request)
        {
            if (request.Browser != null)
            {
                if (request.UserAgent.Contains("Edge")
                    && request.Browser.Browser != "Edge")
                {
                    Name = "Edge";
                }
                else
                {
                    Name = request.Browser.Browser;
                    Version = request.Browser.MajorVersion.ToString();
                }
                Browser = request.Browser;
                Platform = request.Browser.Platform;
                IsMobileDevice = request.Browser.IsMobileDevice;
                if (IsMobileDevice)
                {
                    Name = request.Browser.Browser;
                    Name = request.Browser.Browser;
                }
            }
        }
        public HttpBrowserCapabilitiesBase Browser { get; }
        public string Name { get; }
        public string Version { get; }
        public string Platform { get; }
        public bool IsMobileDevice { get; }
        public string MobileBrand { get; }
        public string MobileModel { get; }
    }
