    //Action method
      public ActionResult Login(LoginViewModel model)
      {
        //Do stuff and populate DashboardViewModel
         UserViewModel userViewModel = new UserViewModel {Username = "username", Password ="secret", FirstName = "John", LastName = "Doe"};
         DashboardViewModel model = new DashboardViewModel {UserViewModel = userViewModel   };
         return RedirectToAction("Index", "Dashboard", model);
      }
