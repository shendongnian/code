     switch (result)
               {
                   case SignInStatus.Success:
                       //check if user is admin
                       var adminRole = context.Roles.Where(r => r.Name == "Administrator").FirstOrDefault();
                       var user = context.Users.Where(u => u.UserName == model.Username).FirstOrDefault();
                       if(user.Roles.Where(r => r.RoleId == adminRole.Id).Count() > 0)
                       {
                           return RedirectToAction("Index", "MIS");
                       }
                       else
                           return View();
