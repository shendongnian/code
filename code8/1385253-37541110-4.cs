    public ActionResult SelectLanguage(string SelectedLanguage) 
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(SelectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedLanguage.ToLower());
            HttpCookie LangCookie = new HttpCookie("LangCookie");
            LangCookie.Value = SelectedLanguage;
            Response.Cookies.Add(LangCookie);
            return RedirectToAction("Index", "Home");
        }
