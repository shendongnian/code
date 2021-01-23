        public ActionResult Index(string returnUrl = "")
        {
            ViewBag.Title = "Smartmultiservices.in | Login";
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                TempData["returnUrl"] = returnUrl;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string username = fc["username"].ToString();
            string password = fc["password"].ToString();
            var query = (from u in db.tbl_user
                         where u.USERNAME == username && u.PASSWORD == password
                         select u).FirstOrDefault();
            if (query != null)
            {
                Session["username"] = username;
                Session["login"] = true;
                if (TempData["returnUrl"] != null && !string.IsNullOrWhiteSpace(TempData["returnUrl"].ToString()))
                    return Redirect(TempData["returnUrl"].ToString());
                else
                    return RedirectToAction("Index", "User");
            }
            return View("Index");
        }
