     namespace Nop.Plugin.Test.Pohoda
        {
            public partial class RouteProvider : IRouteProvider
            {
                public void RegisterRoutes(RouteCollection routes)
                {
                    routes.MapRoute("Plugin.Test.Pohoda.ImportProductInfo",
                          "TestPohoda/ImportProductInfo/{productId}",
                          new { controller = "TestPohoda", action = "ImportProductInfo" , productId = = UrlParameter.Optional },
                          new[] { "Nop.Plugin.Test.Pohoda.Controllers" }
                    );
                }
                public int Priority
                {
                    get
                    {
                        return 1;
                    }
                }
            }
        }
