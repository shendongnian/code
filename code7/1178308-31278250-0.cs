     protected void Application_BeginRequest(object sender, EventArgs e)
     {
         if (Request.Cookies["myLang"] == null)
         {
                var myLang = new HttpCookie("myLang");
                myLang.Value = "en";
                myLang.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myLang);
         }
          Thread.CurrentThread.CurrentUICulture = new CultureInfo(Request.Cookies["myLang"].Value);
          Thread.CurrentThread.CurrentCulture =
          CultureInfo.CreateSpecificCulture(Request.Cookies["myLang"].Value);
    }
