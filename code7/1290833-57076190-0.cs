     routes.MapRoute(
               name: "SubCategoryAction",
               url: "{action}/{id}/{pid}",
               defaults: new { controller = "ControllerName", action = "ActionName", id = UrlParameter.Optional ,pid= UrlParameter.Optional }
               );
    //And access it from controller as
    [AttributeRouting.Web.Mvc.Route("{action}/{id}/{pid}")]    
    public ActionResult ActionName(string id,string pid){}
