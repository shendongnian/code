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
