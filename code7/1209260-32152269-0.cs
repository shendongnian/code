    public ActionResult Index()
    {
      // Display a collection on all orders
    }
    public ActionResult Details(int ID)
    {
      // Display the details of an order, including a collection of its order items
    }
    public ActionResult Create()
    {
      // Create a new Order
    }
    [HttpPost]
    public ActionResult Create(Order model)
    {
      // Save the order
      return RedirectToAction("Details", new { ID = model.ID });
    }
