    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
         var checkEMail = db.AspNetUsers.Where(a=>a.Email == model.Email).FirstOrDefault();
         if(checkEMail != null)
          {
               //Email is not valid
          }
         else
         {              
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var student = new Student { email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
    
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");
    
    
                    ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                                    + "before you can log in.";
                    db.Students.Add(student);
                    db.SaveChanges();
                    return View("Info");
    
                    //return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
          }
    }
