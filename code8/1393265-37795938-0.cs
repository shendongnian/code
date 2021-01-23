    public class CrmObjects
    {
        public IServiceProvider ServiceProvider { get; set; }
        public ITracingService TracingService { get; set; }
        public IPluginExecutionContext PluginContext { get; set; }
        public IOrganizationService Service { get; set; }
    }
    public abstract class BasePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var crmObjects = new CrmObjects();
            crmObjects.ServiceProvider = serviceProvider;
            crmObjects.TracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            crmObjects.PluginContext = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            crmObjects.Service = serviceFactory.CreateOrganizationService(crmObjects.PluginContext.UserId);
            ExecutePluginLogic(crmObjects);
        }
        public virtual void ExecutePluginLogic(CrmObjects crmObjects)
        {
            throw new NotImplementedException();
        }
    }
