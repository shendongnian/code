    public class Resolver
    {
       [Inject]
       public IKernal kernal { get; set; }
       public T Resolve<T>(string type)
       {
            return kernal.TryGet<T>(type);
       }
    }
