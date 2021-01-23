    public ActionResult Index()
    {
        var model = new PurchaseOrderViewModel();
        // This information will probably come from querying some data store. 
        // That could be a SQL database for example. But for the purpose
        // of this sample we are just hardcoding some values to illustrate 
        // the concept without any dependencies
        model.PurchaseOrderItems = new[]
        {
            new PurchaseOrderItem
            {
                Quantity = 5,
            }
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(PurchaseOrderViewModel model)
    {
        // ... everything gets bound correctly here
    }
