        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("CurrentCulture");
            string cultureCode = cookie != null && !string.IsNullOrEmpty(cookie.Value) ? cookie.Value : "en";
            CultureInfo ci = new CultureInfo(cultureCode);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureCode);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
