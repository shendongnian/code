    [HttpPost]
    [AjaxAction]
    public ActionResult Registration(RegisterUserModel registerUser)
    {
        JsonResult data;
    
        if (ModelState.IsValid)
        {
            if (!IsUserExist(registerUser.Email))
            {    
    
                var crypto = new SimpleCrypto.PBKDF2();
    
                var encrpPass = crypto.Compute(registerUser.Password);
    
                var newUser = _db.Users.Create();
    
                newUser.Name = registerUser.Name;
                newUser.Email = registerUser.Email;
                newUser.Type = UserType.User.ToString();
    
                newUser.Password = encrpPass;
                newUser.PasswordSalt = crypto.Salt;
    
                _db.Users.Add(newUser);
                _db.SaveChanges();
    
                data = Json(new { status = "OK", message = "Success" }, JsonRequestBehavior.AllowGet);
    
            }
            else
            {
    
                data = Json(new { status = "ERROR", message = "User already exists"}, JsonRequestBehavior.AllowGet);
            }
        }
        else
        {
    
            data = Json(new { status = "ERROR", message = "Data is incorrect" }, JsonRequestBehavior.AllowGet);
        }
        return data;
    }
