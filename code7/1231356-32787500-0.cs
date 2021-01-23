       void context_BeginRequest(object sender, EventArgs e)
       {
          if (HttpContext.Current.Request.Cookies["culture"] != null)
          {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["culture"];
            string lang = cookie.Value;
            var culture = new System.Globalization.CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
          }
       }
