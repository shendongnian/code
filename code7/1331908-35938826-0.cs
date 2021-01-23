            public ActionResult Login(User u)
            {
                // this action is for handle post (login)
                if (ModelState.IsValid) // this is check validity
                {
                    using (projectEntities dc = new projectEntities())
                    {
                        var v = dc.service_provider.Where(a => a.Sp_email.Equals(u.Email) && a.Sp_password.Equals(u.Password)).FirstOrDefault();
                        if (v != null)
                        {
                            //return RedirectToAction("AfterLogin");
                        
                            int id = u.ID; // assign your valid user's id and pass it to AfterLogin Action
                            return RedirectToAction("AfterLogin", new {@id=id});
                        }
                    }
                }
                return View(u);
            }
        public ActionResult AfterLogin(int id)
        {
            User u = // select your user's data using id and assign to a user object 
            return View(u); // and pass the user object to view
        }
