    public void Configuration(IAppBuilder appBuilder)
    {
        var config = new HttpConfiguration();
    
        ...
    
        config.Routes.MapHttpRoute(
             name: "Default",
             routeTemplate: "{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
        );
    
        config.Routes.MapHttpRoute(
             name: "DeliveryStatusService",
             routeTemplate: "SpecialDeliveryServiceStatus/{deliveryType}/{orderId}",
             defaults: new {
                 controller = "DeliveryStatus",
                 orderId = RouteParameter.Optional
             }
        );
    }
