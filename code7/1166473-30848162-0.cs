    public ActionResult LogIn()
            {
                return View(new ForLogIn());
            }
    
            [HttpPost]
            public ActionResult LogIn(ForLogIn user)
            {
                try 
                {
    	            if(ModelState.IsValid)
                    {
                        var loggedUser=userService.Users.FirstOrDefault(i=>i.UserName==user.UserName && i.UserPassword==user.UserPassword);
                        if(loggedUser!=null)
                        {
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            return View("LoggedIn", loggedUser);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Username or password is incorrect, please try again");
                            return View(user);
                        }
                    }
                    else
                    {
                        return View(user);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(user);
                }
            }
