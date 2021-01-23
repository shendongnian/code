     public ActionResult Changepassword(tblUser login)
        {
           using (UserDetailsEntities db = new UserDetailsEntities())
           {
               var detail = db.tblUsers.Where(log => log.Password == login.Password 
               && log.email == login.email).FirstOrDefault();
               if (detail != null)
               {
                       userDetail.Password = login.NewPassword;
        
                       db.SaveChanges();
                       ViewBag.Message = "Record Inserted Successfully!";
        
                  }
         else
                   {
                       ViewBag.Message = "Password not Updated!";
                   }
        
              
           }
        
           return View(login);
        }
