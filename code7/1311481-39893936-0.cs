    public class XmlSitemapRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
           UmbracoContext current = UmbracoContext.Current;
            if (current == null)
            {
                var httpBase = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current);
                current = UmbracoContext.EnsureContext(
                httpBase,
                ApplicationContext.Current,
                new WebSecurity(httpBase, ApplicationContext.Current),
                UmbracoConfig.For.UmbracoSettings(),
                UrlProviderResolver.Current.Providers,
                false);
            }
            IPublishedContent publishedContent = this.FindContent(requestContext, current);
            if (publishedContent == null)
            {
                return new NotFoundHandler();
            }
            
            
            Uri originalRequestUrl = requestContext.HttpContext.Request.Url;
            
            Uri cleanedUmbracoUrl = UriUtility.UriToUmbraco(originalRequestUrl);
            current.PublishedContentRequest = new PublishedContentRequest(cleanedUmbracoUrl, current.RoutingContext, UmbracoConfig.For.UmbracoSettings().WebRouting, (string s) => Roles.Provider.GetRolesForUser(s))
            {
                PublishedContent = publishedContent
            };
            this.PreparePublishedContentRequest(current.PublishedContentRequest);
            RenderModel value = new RenderModel(current.PublishedContentRequest.PublishedContent, current.PublishedContentRequest.Culture);
            requestContext.RouteData.DataTokens.Add("umbraco", value);
            requestContext.RouteData.DataTokens.Add("umbraco-doc-request", current.PublishedContentRequest);
            requestContext.RouteData.DataTokens.Add("umbraco-context", current);
            requestContext.RouteData.DataTokens.Add("umbraco-custom-route", true);
            
            return new MvcHandler(requestContext);
        }
        protected IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var umbracoHelper = new UmbracoHelper(umbracoContext);
            return umbracoHelper.TypedContent(_sitemapNodeId);
        }
        protected virtual void PreparePublishedContentRequest(PublishedContentRequest publishedContentRequest)
        {
            publishedContentRequest.Prepare();
        }
    }
