    @using Your.Decrypt.Method.Path;
    
    [HttpGet]
    public ActionResult Edit(int id)
    {
        User user = new Repository().GetUser(id);
    
        return View(new EditViewModel()
        {
            Code = user.Code,
            UserName = getDecrypt_Account(user.UserName),
            FullName = user.FullName
        });
    }
