    public class ServiceHostFactory : 
    
        System.ServiceModel.Activation.ServiceHostFactory
            {
         
                protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
                {
                    var host = base.CreateServiceHost(serviceType, baseAddresses);
                    host.Description.Behaviors.Add(ServiceConfig.ServiceMetadataBehavior);
                    ServiceConfig.Configure((ServiceDebugBehavior)host.Description.Behaviors[typeof(ServiceDebugBehavior)]);
                    return host;
                }
            }
