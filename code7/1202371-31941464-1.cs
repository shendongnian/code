    //make sure you added this line in the using section
    using Microsoft.AspNet.Identity.Owin
    
    string fullname = HttpContext.Current.GetOwinContext()
        .GetUserManager<ApplicationUserManager>()
        .FindById(HttpContext.Current.User.Identity.GetUserId()).FullName;
    
