        public ActionResult Create()
        {
            HttpCookie cookie = new HttpCookie("MyCookie");
            cookie.Value = "Hello..Its my world";
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
        //Read Cookie
        public ActionResult Index()
        {
            string cookie = "";
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("MyCookie"))
            {
                cookie = this.ControllerContext.HttpContext.Request.Cookies["MyCookie"].Value;
            }
            ViewData["MyCookie"] = cookie;
            return View();
        }
