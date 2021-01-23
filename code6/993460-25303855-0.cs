    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1Implementation  : IService1
    {
       private ConfigSettings _configSettings;
       public Service1(ConfigSettings settings)
       {
         //now you have the settings in the service
         _configSettings = setting;
       }
    
       ...
    }
    
    //in the Windows Service
    myServiceHost = new ServiceHost(typeof(Service1Implementation), new Service1Implementation(myConfig));
    myServiceHost.Open();
