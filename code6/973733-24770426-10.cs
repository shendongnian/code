    public class MyHttpControllerSelector : IHttpControllerSelector
    {
        private const string ActionKey = "action";
        private const string ControllerKey = "controller";
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
        public MyHttpControllerSelector(HttpConfiguration config)
        {
            _configuration = config;
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }
        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
            var controllerTypes = GetControllerTypes();
            foreach (var type in controllerTypes)
            {
                var controllerName = type.Name.Remove(type.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
                dictionary[controllerName] = new HttpControllerDescriptor(_configuration, type.Name, type);  
            }
            return dictionary;
        }
        private IEnumerable<Type> GetControllerTypes()
        {
            var assembliesResolver = _configuration.Services.GetAssembliesResolver();
            var controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();
            return controllersResolver.GetControllerTypes(assembliesResolver);
        }
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }
        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = GetRouteData(request);
            var controllerName = GetRequestedControllerName(routeData);
            var actionName = GetRequestedActionName(routeData);
            var isApiRoute = GetIsApiRoute(routeData);
            var controllerSelectorKey = GetControllerSelectorKey(actionName, controllerName, isApiRoute);
            return GetControllerDescriptor(request, controllerSelectorKey);
        }
        private bool GetIsApiRoute(IHttpRouteData routeData)
        {
            return routeData.Route.RouteTemplate.Contains("api/");
        }
        private static IHttpRouteData GetRouteData(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return routeData;
        }
        private HttpControllerDescriptor GetControllerDescriptor(HttpRequestMessage request, string controllerSelectorKey)
        {
            HttpControllerDescriptor controllerDescriptor = null;
            if (!_controllers.Value.TryGetValue(controllerSelectorKey, out controllerDescriptor))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return controllerDescriptor;
        }
        private static string GetControllerSelectorKey(string actionName, string controllerName, bool isApi)
        {
            return string.IsNullOrWhiteSpace(actionName) || !isApi
                ? controllerName
                : string.Format("{0}{1}", controllerName, "Rpc");
        }
        private static string GetRequestedControllerName(IHttpRouteData routeData)
        {
            string controllerName = GetRouteVariable<string>(routeData, ControllerKey);
            if (controllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return controllerName;
        }
        private static string GetRequestedActionName(IHttpRouteData routeData)
        {
            return GetRouteVariable<string>(routeData, ActionKey);
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }
    }
