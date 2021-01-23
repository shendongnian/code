    public ActionResult Create([Bind(Include = "Make,Model")] Car car)
    {
         if(//Your Condition upon which you want to model validation throw error) {
            ModelState.AddModelError("Make", "Check your spelling");
          }
         if (ModelState.IsValid) {
           //Rest of your logic 
         }
       return View(car);
     }
