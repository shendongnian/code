    public class ViewModel
    {
        public ViewModel() 
        {
            UnitPrice = 100M;
        }
        ...
        // if you want constant read-only model in runtime, use readonly keyword before decimal and declare its constructor value
        public decimal UnitPrice { get; set; } 
    }
    [HttpGet]
    public ActionResult YourView()
    {
         ViewModel model = new ViewModel() 
         {
              model.Price = 100M; // if the property is not read-only
         };
         // other logic here
         return View(model);
    }
    // validation on server-side
    [HttpPost]
    public ActionResult YourView(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            // some logic here
        }
    
        // return type here
    }
