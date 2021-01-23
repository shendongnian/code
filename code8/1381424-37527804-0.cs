        OutputCache(NoStore = true, Duration = 0)]
        // set language on select(view) and create a cookie  
        [HttpGet]
        public ActionResult SetCulture(string idiomString)
        {
                       
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = idiomString;   
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = idiomString;
            }
            Response.Cookies.Add(cookie); 
            
            return RedirectToAction("Index");
        }
        // set the language 
         protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state) 
        {
            string cultureName = null;
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages["0"]; 
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }
