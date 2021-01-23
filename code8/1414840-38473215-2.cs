    public class ConsumerSample
    {
       privare IRegistryService _registryService;
            
       public ConsumerSample(IRegistryService registryService)
       {
          _registryService = registryService;
       }
            
       public void DoStuffAndUseRegistry()
       {
           // stuff
           // now let's save
           _registryService.CreateHkcuRegistry("test","testValue","mytest");
       } 
    }
            
            
    var consumer = new ConsumerSample(new RegistryService());
