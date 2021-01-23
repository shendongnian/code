    public class Service1 : ServiceBase, IInstanceProvider
    {
    
      private ConfigSettings _myConfig; //assign this member later on
      ...
      //IInstanceProvider implementation
    
      public object GetInstance(InstanceContext instanceContext, Message message)
      {
          //this is how you inject the config
          return new Service1Implementation(_myConfig);
      }
    
      public object GetInstance(InstanceContext instanceContext)
      {
          return this.GetInstance(instanceContext, null);
      }
    
      public void ReleaseInstance(InstanceContext instanceContext, object instance)
      {
      }
      ...
    }
