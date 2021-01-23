    public ActionResult Something()
    {
      var vm = new ProductBasket();
      
     //The below line is hard coded for demo. You may replace with actual list from db.
      vm.Products.Add(new ProductConfiguration { Id=1,Name="test"});
     
      return View(vm);
    }
