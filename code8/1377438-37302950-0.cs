    [TestClass]
    public class UnitTestWebsiteBuilderPattern
    {
        private IHtmlInputService _htmlInputService;
        private IHtmlControlService _htmlControlService;
        private IHtmlMenuControlService _htmlMenuControlService;
        private IHtmlConditionalInputService _htmlConditionalInputService;
        private IHtmlPanelService _htmlPanelService;
        private IHelpIconService _helpIconService;
        private IHtmlModalService _htmlModalService;
        [TestInitialize]
        public void Init()
        {
            _helpIconService = new HtmlHelpIconService();
            _htmlInputService = new HtmlInputService(_helpIconService);
            _htmlPanelService = new HtmlPanelService(_htmlInputService);
            _htmlModalService = new HtmlModalService(_htmlPanelService);
            _htmlControlService = new HtmlControlService(_htmlPanelService);
            _htmlMenuControlService = new HtmlMenuControlService();
            _htmlConditionalInputService = new HtmlConditionalInputService();
        }
