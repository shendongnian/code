    public ActionResult Create()
    {
      // Get all available bikes, for example
      var inventory = db.Inventory;
      OrderVM model = new OrderVM
      {
        Inventory = inventory.Select(i => new
        {
          ID = i.ID,
          Name = i.Model // modify this to suit what you want to display in the view
        }
      };
      return View(model);
    }
