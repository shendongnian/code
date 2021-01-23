    public sealed class ValuesController : ApiController
    {
        private IWidgetService WidgetService { get; }
        public ValuesController(IWidgetService widgetService)
        {
            if(widgetService == null) 
                throw new ArgumentNullException(nameof(widgetService));
            WidgetService = widgetService;
        }
        [HttpGet]
        public IEnumerable<Widget> Get()
        {
            return WidgetService.GetWidgets().ToArray();
        }
    }
