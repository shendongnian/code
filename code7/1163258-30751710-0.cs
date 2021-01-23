     public ActionResult Index(MainViewModel viewModel)
        {                       
            var users = context.Users.ToList(); //use your dbContext
            List<MainViewModel> viewModelList = users
                .Select(u => new MainViewModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Company = u.Company
                }).ToList();
                
            return View(viewModelList);
        }
