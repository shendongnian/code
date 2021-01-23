    [Route("{id}"), HttpGet]
    public IHttpActionResult Test(int? id) //the easiest way to get route value for {id}
    {
        // Simple and easy
        var route1 = Request.GetRouteData().Values["id"];
    
        // Wat. This is also ~6 times slower
        var routeValues = (IHttpRouteData[]) HttpContext.Current.Request.RequestContext.RouteData.Values["MS_SubRoutes"];
        var route2 = routeValues.SelectMany(x => x.Values).Where(x => x.Key == "id").Select(x => x.Value).FirstOrDefault();
    
        return Ok(route1 == route2 == id.Value); // true //should be true, and of course you should add null check since it is int? not int. But that is not significant here so I didn't do it.
    }
