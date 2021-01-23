    public partial class App : Application
        {
            public static Repository<Personel, YBSDbContext> repo = new Repository<Personel, YBSDbContext>(new YBSDbContext());
    
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
    
                var bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
        }
