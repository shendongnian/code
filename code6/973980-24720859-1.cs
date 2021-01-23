    [HttpPost]
    public ActionResult Register(RegistrationViewModel viewModel) {
       User user = viewModel.ToUser(); // <-- this is an AutoMapper helper
         
       // now pass that to your business logic layer and do magic
       _userManager.Register(user);
    }
