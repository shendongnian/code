    public ActionResult Index(IndexViewModel profile)
    {
        if (ModelState.IsValid)
        {
            List<User> users = new List<User>();
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal qbeUser = new UserPrincipal(ctx);
                qbeUser.DisplayName = profile.Name + "*";
    
                using (PrincipalSearcher srch = new PrincipalSearcher(qbeUser))
                {
                    if(!(srch.FindAll().Count() < 0))
                    {
                        foreach(var found in srch.FindAll())
                        {
                            users.Add(new User() {
							  Name = found.Name,
							  Email = found.Email,
							  Description = found.Description
							});
                        }
                    }                       
					
					IndexViewModel returnmodel = new IndexViewModel(users);
                    return View(returnmodel);
                }
            }
        }
    
        return View(profile);
    }
	
