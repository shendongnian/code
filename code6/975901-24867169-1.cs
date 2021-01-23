    public class LocaleParser : IHttpModule
    {
       public void Init(HttpApplication context)
       {
          context.BeginRequest += context_BeginRequest;
       }
       void context_BeginRequest(object sender, EventArgs e)
       {
           var req = HttpContext.Current.Request.Url.AbsoluteUri;
           var targetUrl = req;
            if (req.IndexOf('/') != -1)
            {
                var langparm = req.Split('/')[1].ToLower();
                switch (langparm)
                {
                    case "pt":
                        HttpContext.Current.Items["locale"] = "PT";
                        targetUrl = req.Substring(3);
                        break;
                    case "en":
                        HttpContext.Current.Items["locale"] = "EN";
                        targetUrl = req.Substring(3);
                        break;
                    case "es":
                        HttpContext.Current.Items["locale"] = "ES";
                        targetUrl = req.Substring(3);
                        break;
                }
            }
        }
    }
