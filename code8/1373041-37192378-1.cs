    public class App : MvxApplication
    {
        public override void Initialize()
        {
           // Example Other registrations
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
    
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
        }
    }
