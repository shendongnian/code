    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ODataV3 = System.Web.Http.OData;
    using ODataV4 = System.Web.OData;
    
    namespace MyProject
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // OData V3 Route
    
                ODataV3.Builder.ODataModelBuilder builder3 = new ODataV3.Builder.ODataConventionModelBuilder();
    
                builder3.EntitySet<MarvelCharacter>("MarvelCharactersV3");
                // The MapODataRoute function is deprecated in WebAPI 2.2,
                // but I haven't found an alternative for supporting OData 3.
                config.Routes.MapODataRoute(
                    routeName: "Marvel3",
                    routePrefix: "dude3",
                    model: builder3.GetEdmModel());
    
                // ODate V4 Route
    
                ODataV4.Builder.ODataModelBuilder builder4 = new ODataV4.Builder.ODataConventionModelBuilder();
    
                builder4.EntitySet<MarvelCharacter>("MarvelCharactersV4");
                ODataV4.Extensions.HttpConfigurationExtensions.MapODataServiceRoute(
                    configuration: config,
                    routeName: "Marvel4",
                    routePrefix: "dude4",
                    model: builder4.GetEdmModel());
            }
        }
    }
