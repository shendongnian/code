    public interface IMock { }
    public class TestEchoRepo : IEchoRepo, IMock
    {
        public string Say()
        {
            return "TestEchoRepo";
        }
    }
    // Test environment
    builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.IsAbstract == false && t.Name.EndsWith("Repo"))
                .Where(t => typeof(IMock).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerRequest();
