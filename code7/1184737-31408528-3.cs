     [HttpGet]
     public ActionResult Create()
     {         
         var model = new List<Order>();
         return View(model);
     }
     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Create(List<Order> orders)
     {
         // Update code omitted
         return View(order);
     }
