    public ActionResult Index()
        {
           using(var context = new IdentityDbContext()){
        viewModel =
            context.Users
            .Include("Roles")
            .Select(u =>
                new UserRoleViewModel { 
                    UserRoleVMId = u.Id, 
                    Title = u.Title,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    Email = u.Email,
                    AccountEnabled = u.AccountEnabled,
                    Role = u.Roles.First().Role.ToString() 
                }
            ).ToList();
         }
    
            return View(viewModel);
        }
