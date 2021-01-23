    [HttpPost]
    public ActionResult Index(Models.customer cs )
    {
            if(isValid(cs.email, cs.password))
            {
                Session["user"] = cs.email;
                FormsAuthentication.SetAuthCookie(cs.email, false);
                customer c = customerEntity.customers.Single(e => e.email == cs.email);
                return MemberInfo(c);
            }
            ModelState.AddModelError(string.Empty, "Authentication Failed");
            return View(cs);
    }
