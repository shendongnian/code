    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        const string partName = "Webapi.Controllers";
        private readonly HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }
        public override System.Web.Http.Controllers.HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var _route = request.GetRouteData();
            var controllerName = base.GetControllerName(request);
            var type = _config.Services.GetAssembliesResolver();
            var controlles = _config.Services.GetHttpControllerTypeResolver().GetControllerTypes(type);
            object name;
            _route.Values.TryGetValue("route", out name);
            var st = name as string;
            if (st != null)
            {
                var conType = controlles.FirstOrDefault(a => a.Namespace == string.Format("{0}.{1}", partName, st));
                            if (conType != null)
                                return new System.Web.Http.Controllers.HttpControllerDescriptor(_config, controllerName, conType);
            }
            return base.SelectController(request);
        }
    }
