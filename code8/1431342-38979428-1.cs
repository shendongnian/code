     public ActionResult AddToAdmin(User user)
        {           
            Roles.AddUserToRole(user.UserName, "admin");                    
            return RedirectToAction("Index");             
        }
