    public ActionResult ExampleClass()
    {
            var viewModel = new ViewModel
            {
                Products = db.Products.ToList(), //you can also call just one product here
                Categories = db.Categories .ToList() //same here
            };
            return View(viewModel);;
    }
