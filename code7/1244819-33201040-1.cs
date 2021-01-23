     public ActionResult Index()
     {
                //Get data from database
                return View(new ScrumTimerModel(){Items=listFromDb.Select(t=>
                            new  SelectListItem(){ 
                            Text=t.Name, Value=t.Value
                       }) 
                });
     }
