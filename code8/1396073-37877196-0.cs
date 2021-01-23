    `var user = new ApplicationUser { UserName = model.Email, Email = model.Email,Addresses =a };
    var result = await UserManager.CreateAsync(user, model.Password);
    if(result.Succeeded)
    {
         //assign list of address to user
         IList<Info> infos = new List<Info>() { new Info() { Address ="testAddr",UserId = User.Identity.GetUserId()} }
         dbcontext.SaveChanges()
         //login here
    }`
