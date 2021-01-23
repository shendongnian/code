    public ActionResult Index()
        {
            return View(new RoutesList());
        }
    
    public ActionResult PartialForm(RoutesList route)
    {
       if (!string.IsNullOrEmpty(route.SelectedRouteID))
       return view("__directionForm", route);
       
       return view("...", route); //your other view
    }
    
    [HttpPost]
          public ActionResult Index(RoutesList route, FormCollection frm)
        {
    
            //if (!string.IsNullOrEmpty(route.SelectedRouteID)) ViewBag.isDirection = true;
            //if (!string.IsNullOrEmpty(route.SelectedOppositeRouteID)) ViewBag.isStations = true;
            if(!string.IsNullOrEmpty(route.SelectedFromStationID)&&!string.IsNullOrEmpty(route.SelectedToStationID))
                return RedirectToAction("Index", "Time", new { id = route.SelectedRouteID });
    
            return View(route);
    
        }
