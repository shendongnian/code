    public ActionResult Index()
    {
        db = new CarEntities();
        var model = new CarsViewModel
        {
            Cars = db.Get_Car_List().Select(c=> new SelectListItem
                    {
                       Value = c.id.ToString(),
                       Text = c.name
                    }).ToList()
        };
    
        return View(model);
     }
    [HttpPost]
    public ActionResult Index(CarsViewModel model)
    {
        db = new CarEntities();
    
        var car_id= from o in db.Get_CarSites()
            where o.name == model.SelectedCarId
            select o.id;                        
        //then run another query
        'return View();'
    }
