    public class DerivedFactory : ServiceHostFactory
    {
       public override ServiceHost CreateServiceHost( Type t, Uri[] baseAddresses )
       {
          return new DerivedHost( t, baseAddresses );
       }
    }
