    using (EFNameEntities db = new EFNameEntities())
            {
               var UserData = from ANU in db.AspNetUsers
                               where ANU.UserName == model.UserName
                               select new
                               {
                                   ANU.isAuthorized,
                                   ANU.isActive
                               };
                foreach (var c in UserData)
                {
                    //If User is NOT Authorized to log in
                    if (!Convert.ToBoolean(c.isAuthorized))
                    {
                        ModelState.AddModelError("", "This User is not Authorized to Login.");
                        return View(model);
                    }
                    else
                    {
                        //If User is NOT Active
                        if (!Convert.ToBoolean(c.isActive))
                        {
                            ModelState.AddModelError("", "This User is not Active.");
                            return View(model);
                        }
                    }
                }
            }
