    var costcoBuilder = new ODataConventionModelBuilder();
    costcoBuilder.EntitySet<Costco.Models.Food>("Foods");
    var ikeaBuilder = new ODataConventionModelBuilder();
    ikeaBuilder.EntitySet<Ikea.Models.Food>("Foods");
    config.Routes.MapODataServiceRoute("CostcoRoute", "Costco", costcoBuilder.GetEdmModel());
    config.Routes.MapODataServiceRoute("IkeaRoute", "Ikea", ikeaBuilder.GetEdmModel());
