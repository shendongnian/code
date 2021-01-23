    // using System.Globalization;
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        CultureInfo ci = new CultureInfo("en-US");
        ci.DateTimeFormat.ShortDatePattern = "MM dd yyyy";
        // there are a lot of other pattern properties in ci.DateTimeFormat you can set 
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
    }
