    public interface INamedService
    {
        string Name { get; }
    }
    
    public static T GetService<T>(this IServiceProvider provider, string serviceName)
        where T : INamedService
    {
        var candidates = provider.GetServices<T>();
        return candidates.FirstOrDefault(s => s.Name == serviceName);
    }
