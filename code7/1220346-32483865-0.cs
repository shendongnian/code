	<siteMap>
	  <providers>
		<add name="MvcSiteMapProvider" type="MvcSiteMapProvider.DefaultSiteMapProvider, MvcSiteMapProvider" 
			 siteMapFile="~/Mvc.Sitemap"
			 securityTrimmingEnabled="true"
			 cacheDuration="5"
			 enableLocalization="true"
			 scanAssembliesForSiteMapNodes="true" 
			 excludeAssembliesForScan="" 
			 includeAssembliesForScan="" 
			 attributesToIgnore="hideOnStandard,hideFormatting" 
			 nodeKeyGenerator="MvcSiteMapProvider.DefaultNodeKeyGenerator, MvcSiteMapProvider" 
			 controllerTypeResolver="MvcSiteMapProvider.DefaultControllerTypeResolver, MvcSiteMapProvider"
			 actionMethodParameterResolver="MvcSiteMapProvider.DefaultActionMethodParameterResolver, MvcSiteMapProvider" 
			 aclModule="MvcSiteMapProvider.DefaultAclModule, MvcSiteMapProvider"
			 routeMethod=""
			 siteMapNodeUrlResolver="MvcSiteMapProvider.DefaultSiteMapNodeUrlResolver, MvcSiteMapProvider" 
			 siteMapNodeVisibilityProvider="MvcSiteMapProvider.DefaultSiteMapNodeVisibilityProvider, MvcSiteMapProvider" 
			 siteMapProviderEventHandler="MvcSiteMapProvider.DefaultSiteMapProviderEventHandler, MvcSiteMapProvider" />
	  </providers>
	</siteMap>
