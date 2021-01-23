    [HttpGet]
    public ActionResult Login(string returnUrl)
    {
            if (Request.IsAuthenticated)
            {
               if(string.IsNullOrEmpty(returnUrl))
               {
                   return RedirectToAction("Index", "Home");
               }
               else
               {
                   return RedirectToAction(returnUrl);
               }
            }
            return View();
    }
