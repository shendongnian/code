    public class CustomerController : TableController<Customer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            controllerContext.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            base.Initialize(controllerContext);
            MyMobileAppContext context = new MyMobileAppContext();
            DomainManager = new EntityDomainManager<Customer>(context, Request);
        }
    
    ....
    }
 
