    public ActionResult Create(int ID) // ID is the ID of the Order
    {
      OrderItem model = new OrderItem() { OrderID = ID };
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(OrderItem model)
    {
      // Save the OrderItem and redirect to the order details page
      return RedirectToAction("Details", "Order", new { ID = model.OrderID });
    }
