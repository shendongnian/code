    public class TypeRegistry : Registry
    {
        public TypeRegistry()
        {
            For<ILogger>().Singleton().Use<Log4NetLogger>();
            Policies.FillAllPropertiesOfType<ILogger>().Use<Log4NetLogger>();
        }
    }
