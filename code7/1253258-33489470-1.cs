    public ActionResult Login()
            {
                return View();
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(User l,string ReturnUrl="")
            {
                
                    string EncodedPass;
                    EncodedPass = Crypto.SHA256(l.Pass);
                    
                    var user = db.UserInfo.Where(a => a.Name.Equals(l.Name) && 
                     a.Pass.Equals(EncodedPass)).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(l.Name, false);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Create", "Ministry");
                        }
                    }
                
                ModelState.Remove("Password");
                return View();
    
            }
