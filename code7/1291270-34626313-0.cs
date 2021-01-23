    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(LoginModel usr)
    {      
        if (usr.UserName=="random"&&usr.Password=="randPassword")
        {
            Session["Username"] = usr.UserName.ToString();
            FormsAuthentication.SetAuthCookie(user.UserName, false);
            return Json(new { status="success"});
        }
        else
        {
          return Json(new { status="error" ,error= "UserName or Password is Wrong"});
        }
    }
