    public class HomeController {
        //Action method
          public ActionResult Login(LoginViewModel model)
          {
            //Do stuff and populate AppViewModel
    
             UserViewModel userViewModel = new UserViewModel {Username = "username", Password ="secret", FirstName = "John", LastName = "Doe"};
             AppViewModelmodel model = new AppViewModel{UserViewModel = userViewModel };
             return RedirectToAction("Index", "Dashboard", model);
          }
    }
