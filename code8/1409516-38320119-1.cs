    [HttpGet]
    public ActionResult Index(string returnUrl = "")
    {
    	return View(new AccountLoginModel {ReturnUrl = returnUrl});
    }
    
    [HttpPost]
    public ActionResult Index(AccountLoginModel model)
    {
    	if (!ModelState.IsValid)
    	{
    		return View(model);
    	}
    	
    	var query = (from u in db.tbl_user
    				 where u.USERNAME == model.Username && u.PASSWORD == model.Password
    				 select u).FirstOrDefault();
    	if (query != null){
    		Session["username"] = model.Username;
    		Session["login"] = true;
    	   
    	   if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
    	   {
    			return Redirect(model.ReturnUrl);
    	   }
    	   
    	   return RedirectToAction("Index", "User");
    	}
    
    	ModelState.AddModelError("", "Username and/or Password is incorrect");
    	return View(model);
    }
