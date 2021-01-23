        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel u)
        {
            if (ModelState.IsValid) 
            {
                {
                    var v = entities.Users.Where(a => a.UserName.Equals(u.UserName) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedUserID"] = v.UserID.ToString();
                        Session["LoggedUserFullname"] = v.FirstName +" "+ v.LastName;
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }
