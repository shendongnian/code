     <pipelines>
      <initialize>
            <processor type="Test.Project.Pipelines.Initialize.InitRoutes, Test.Project"
         patch:after="processor[@type='Sitecore.Mvc.Pipelines.Loader.InitializeRoutes, Sitecore.Mvc']" />
     </initialize>
     <pipelines>
