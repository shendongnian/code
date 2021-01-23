    [XMLControllerConfig]
    public class XMLController: ApiController
    {
        [HttpGet]
        public string SomeMethod(string someArgument)
        {
            return "abc";
        }
    }
    
...
    class XMLControllerConfigAttribute: Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, 
                               HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(new XMLFormatter());
        }
    }
