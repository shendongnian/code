    public ActionResult Reviews()
    {
       var model = new List<OdeToFood.Models.RestaurantReview>();
       model.Add(new OdeToFood.Models.RestaurantReview { Name = "Test" });
       model.Add(new OdeToFood.Models.RestaurantReview { Name = "Test2" });
    
       return View(model);
    }
