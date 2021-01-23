    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(LoginModel usr)
    {      
        if (usr.UserName=="random"&&usr.Password=="randPassword")
        {
            // do whatever you have to do 
            return Json(new { status="success"});
        }
        else
        {
          return Json(new { status="error" ,error= "UserName or Password is Wrong"});
        }
    }
