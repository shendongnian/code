    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(HttpContext.Current.Session["userCulture"]);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(HttpContext.Current.Session["userCulture"]);
    }
