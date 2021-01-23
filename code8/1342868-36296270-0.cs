    private static void RegisterServices(IKernel kernel) {
        kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
        kernel.Bind<UserManager<ApplicationUser>>().ToSelf();
        
        kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();
        
        kernel.Bind<ApplicationSignInManager>().ToMethod((context)=>
        {
        	var cbase = new HttpContextWrapper(HttpContext.Current);
        	return cbase.GetOwinContext().Get<ApplicationSignInManager>();
        });
        
        kernel.Bind<ApplicationUserManager>().ToSelf();
	}
	
