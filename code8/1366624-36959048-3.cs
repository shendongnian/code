    [HttpPost]
    public ActionResult Changepassword(tblUser login)
    {
        UserDetailsEntities db = new UserDetailsEntities();
        var detail = db.tblUsers.Where(log => log.Password == login.Password).FirstOrDefault();
        
        // ADD NULL CHECK HERE
        if (detail != null)
        {
            var userDetail = db.tblUsers.FirstOrDefault(c => c.Email == login.Email);
             if(userDetail !=null)
             {
                  userDetail.Password = login.NewPassword;
                  db.SaveChanges();
                  ViewBag.Message = "Record Inserted Successfully!";
             }
        }
        else
        {
            ViewBag.Message = "Password not Updated!";
        }
        return View(login);
    }
