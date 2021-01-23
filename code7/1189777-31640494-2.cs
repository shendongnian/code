    namespace Test.Project.Pipelines.Initialize
    {
        public class InitRoutes : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
        {
            public override void Process(PipelineArgs args)
            {
                RegisterRoutes(RouteTable.Routes);
            }
            protected virtual void RegisterRoutes(RouteCollection routes)
            {
                routes.MapRoute(
                    "Test", // Route name
                    "api/test/{controller}/{action}/{id}", // URL with parameters
                     new { id = UrlParameter.Optional }
                    );
            }
        }
    }
