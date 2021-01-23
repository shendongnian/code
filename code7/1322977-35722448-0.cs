    GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),new MyControllerActivator());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector),new MyControllerSelector());
    public class MyControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            throw new NotImplementedException();
        }
    }
    public class MyControllerSelector : IHttpControllerSelector
    {
        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return new HttpControllerDescriptor() {ControllerName="SomeController",ControllerType=typeof(MyApiController),Configuration=GlobalConfiguration.Configuration};
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
        }
    }
