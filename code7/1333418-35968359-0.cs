#if DEBUG
        public async Task<ActionResult> AutoLogin()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                var controller = DependencyResolver.Current.GetService<AccountController>();
                controller.InitializeController(Request.RequestContext);
                return await controller.Login(new LoginViewModel() { Email = "user@no.com", Password = "passwordHere", RememberMe = false }, "/Home/Index");
            }
            return Content("Not debugging");
        }
#endif
