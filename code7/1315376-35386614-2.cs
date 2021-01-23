    public interface ITypeProvider
    {
        ICollection<Type> GetTypes();
    }
    public class AppDomainTypeProvider : ITypeProvider
    {
        public ICollection<Type> GetTypes()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .ToList();
        }
    }
    public class MyAwesomeClassThatUseMyTypeProvider
    {
        private readonly ITypeProvider _typeProvider;
        public MyAwesomeClassThatUseMyTypeProvider(ITypeProvider typeProvider)
        {
            _typeProvider = typeProvider;
        }
        public void DoSomething()
        {
            var types = _typeProvider.GetTypes();
        }
    }
