     public interface IServiceAccessor<TService>
        {
             void Register(TService service,string name);
             TService Resolve(string name);
        }
