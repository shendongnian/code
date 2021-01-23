    [HttpGet]
    public ActionResult RegisterForm()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult RegisterForm()
    {
        bool success = true;
        String otherData = ""
    
        // Create User Object and populate it with form data
        User currentUser = new User();
        currentUser.Username = Request.Form["username"].Trim().ToString();
    
        // Validate Registration
        // code
    
        // Add user to database
        // code
    
        if (success)
        {
            return RedirectToAction("RegisterSuccess");
        }else
        {
            return View("RegisterForm");
        }
    }
