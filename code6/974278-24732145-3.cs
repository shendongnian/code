    public class MyControllerWithDbDependency : Controller
    {
       MyControllerWithDbDependency(MyDbFileSystemService dbFileSystemService,
                                    ISomeOtherDependency ...)
       {
          // ...
       }
    }
    // AutoFac configuration
    builder.RegisterType<MyDbFileSystemService>()
       .As<MyDbFileSystemService>()
       .InstancePerWhatever();
    builder.RegisterType<DefaultFileSystemService>()
       .As<IFileSystemService>()
       .InstancePerWhatever();
