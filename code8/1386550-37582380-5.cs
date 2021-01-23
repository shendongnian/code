    public ActionResult CreateMenu( )
    {
        // Get all the dishes from the database
        var dishes = db.Dishes; // modify to suit
        // Initialize the view model
        var model = new MenuVM()
        {
            Dishes = dishes.Select(x => new DishVM()
            {
                ID = x.Id,
                Name = x.Name
            }).ToList()
        };
        return View(model);
    }
