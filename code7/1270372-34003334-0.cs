    routes.MapRoute("DesignIdeasDetails", "ideadetails/{id}",
              (await MVC.Designer.IdeaDetails()).AddRouteValue("id", UrlParameter.Optional)
    
    // or, if the method cannot be used with async/await
     routes.MapRoute("DesignIdeasDetails", "ideadetails/{id}",
              (MVC.Designer.IdeaDetails().GetAwaiter().GetResult()).AddRouteValue("id", UrlParameter.Optional)
