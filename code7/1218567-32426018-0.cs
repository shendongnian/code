    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Text;
    namespace NitinJS
    {
        public class SmsWebClient : WebClient
        {
            public SmsWebClient(CookieContainer container, Dictionary<string, string> Headers)
                : this(container)
            {
                foreach (var keyVal in Headers)
                {
                    this.Headers[keyVal.Key] = keyVal.Value;
                }
            }
            public SmsWebClient(bool flgAddContentType = true)
                : this(new CookieContainer(), flgAddContentType)
            {
            }
            public SmsWebClient(CookieContainer container, bool flgAddContentType = true)
            {
                this.Encoding = Encoding.UTF8;
                System.Net.ServicePointManager.Expect100Continue = false;
                ServicePointManager.MaxServicePointIdleTime = 2000;
                this.container = container;
                if (flgAddContentType)
                    this.Headers["Content-Type"] = "application/json";//"application/x-www-form-urlencoded";
                this.Headers["Accept"] = "application/json, text/javascript, */*; q=0.01";// "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //this.Headers["Accept-Encoding"] = "gzip, deflate";
                this.Headers["Accept-Language"] = "en-US,en;q=0.5";
                this.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; rv:23.0) Gecko/20100101 Firefox/23.0";
                this.Headers["X-Requested-With"] = "XMLHttpRequest";
                //this.Headers["Connection"] = "keep-alive";
            }
            private readonly CookieContainer container = new CookieContainer();
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest r = base.GetWebRequest(address);
                var request = r as HttpWebRequest;
                if (request != null)
                {
                    request.CookieContainer = container;
                    request.Timeout = 3600000; //20 * 60 * 1000
                }
                return r;
            }
            protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
            {
                WebResponse response = base.GetWebResponse(request, result);
                ReadCookies(response);
                return response;
            }
            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                ReadCookies(response);
                return response;
            }
            private void ReadCookies(WebResponse r)
            {
                var response = r as HttpWebResponse;
                if (response != null)
                {
                    CookieCollection cookies = response.Cookies;
                    container.Add(cookies);
                }
            }
        }
    }
