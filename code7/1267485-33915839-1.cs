    [HttpGet]
        public ActionResult Login(string returnUrl = "www.yourDomain.com/login")
        {
                if (Request.IsAuthenticated)
                {
                   return RedirectToAction(returnUrl);
                }
                return View();
        }
