    public ActionResult Confirm()
    {
      var vm = new Confirm();
      vm.Cart= new ShoppingCartViewModel();
      // Load the Shopping cart property values to vm.Cart
      return View(vm);
    }
