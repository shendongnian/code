    public class RegisterModule : NancyModule
    {
        public RegisterModule()
        {
            Get["/register"] = _=> {
              return View["register"]; // return register view
            };
            Post["/register"] = _ => {
              // 1. get model
              var model = this.Bind<RegisterModel>();
              // 2. create new User
              // ...
              // 3. redirect To /login with post data (pseudocode)
              return 
                  Negotiate
                  .WithStatusCode(HttpStatusCode.TemporaryRedirect)
                  .WithHeader("Location", "/login");
          };
       }
    }
