    container.RegisterType<IAuthenticationManager>(
        new InjectionFactory(
            o => System.Web.HttpContext.Current.GetOwinContext().Authentication
        )
    );
