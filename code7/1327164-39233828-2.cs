            kernel.Bind<ApplicationUserManager>().ToSelf()
                .InRequestScope();
            kernel.Bind<ApplicationSignInManager>().ToSelf().InRequestScope();
            kernel.Bind<IAuthenticationManager>()
                .ToMethod(m => HttpContext.Current.GetOwinContext().Authentication)
                .InRequestScope();
            kernel.Bind<IIdentity>().ToMethod(p => HttpContext.Current.User.Identity).InRequestScope();
            kernel.Bind<ICurrentUser>().To<AspNetIdentityCurrentUser>();
