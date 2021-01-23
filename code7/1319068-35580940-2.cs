    public class TemplatingService : ITemplatingService
    {
        private readonly IRazorEngineService _razorEngineService;
        public TemplatingService(Assembly assembly, string templatesNamespace)
        {
            var config = new TemplateServiceConfiguration();
            config.TemplateManager = new EmbeddedResourceTemplateService(assembly, templatesNamespace);
    #if DEBUG
            config.Debug = true;
    #endif
            this._razorEngineService = RazorEngineService.Create(config);
        }
        public void CacheTemplate(string templateName, Type type)
        {
            var templateKey = new NameOnlyTemplateKey(templateName, ResolveType.Layout, null);
            this._razorEngineService.Compile(templateKey, type);
        }
        public string RunTemplate(string templateName, Type type, object model, IDictionary<string, object> dynamicViewBag = null)
        {
            var templateKey = new NameOnlyTemplateKey(templateName, ResolveType.Layout, null);
            return this._razorEngineService.RunCompile(templateKey, type, model, dynamicViewBag != null ? new DynamicViewBag(dynamicViewBag) : null);
        }
    }
