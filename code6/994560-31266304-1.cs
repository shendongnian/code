    public class PublishedPageRouteHandler :  UmbracoVirtualNodeRouteHandler
    {
        private readonly int _pageId;
    
        public PublishedPageRouteHandler(int pageId)
        {
            _pageId = pageId;
        }
       
        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var helper = new UmbracoHelper(umbracoContext);
            return helper.TypedContent(_pageId);
        }
    }
