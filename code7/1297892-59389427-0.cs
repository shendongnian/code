 c#
public class RedisCacheProvider : ICacheProvider
{
    private readonly string _connectionString;
    private readonly IMyInterface _myImplementation;
    public RedisCacheProvider(string connectionString, IMyInterface myImplementation)
    {
        _connectionString = connectionString;
        _myImplementation = myImplementation;
    }
    //interface methods implementation...
}
Startup.cs:
 C#
services.AddSingleton<IMyInterface, MyInterface>();
services.AddSingleton<ICacheProvider>(provider => 
    RedisCacheProvider("myPrettyLocalhost:6379", provider.GetService<IMyInterface>()));
