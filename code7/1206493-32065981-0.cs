    protected override void Load(ContainerBuilder builder)
    {
           builder.Register(
                    c => (HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>())
                        .FindById(HttpContext.Current.User.Identity.GetUserId())).As<ApplicationUser>();
    }
