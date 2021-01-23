    public class NinjectMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<MyContext>().ToSelf().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IFilterProvider>().To<PermissionFilterProvider>();
            Bind<PermissionFilter>().ToSelf();
        }
    }
