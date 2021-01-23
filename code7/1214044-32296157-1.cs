    public interface IMock<T> where T : class { } 
    public class TestEchoRepo: IEchoRepo, IMock<IEchoRepo>
    {
       ...
    }
    // Test environment
    builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.IsAbstract == false)
                .Where(t => t.IsClosedTypeof(typeof(IMock<>)))
                .AsImplementedInterfaces()
                .InstancePerRequest();
    
