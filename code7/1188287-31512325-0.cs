    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(Employee emp, string returnUrl)
               {
                using(AdaptiveProjectEntities db = new AdaptiveProjectEntities())
                {
                    string email = emp.Email;
                   // byte[] en = System.Text.Encoding.UTF8.GetBytes(emp.Password);
                    //var ee = Convert.ToBase64String(en);
                    string pass = emp.Password;
                    
                    bool userValid = db.Employees.Any(user => user.Email == email && user.Password == pass);
                        if(userValid)
                        {
                            FormsAuthentication.SetAuthCookie(email, false);
                           
                            
                             
                             if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                               
                        return RedirectToAction("Index", "Projects");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                        }
    
                
                 
                return View(emp); 
    
           }
            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Login");
            }
        }
    }
