    public ActionResult AddressAndPayment()
    { 
        var cart = ShoppingCart.GetCart(this.HttpContext);
        if(!cart.GetCartItems().Any())
            return RedirectToAction("Index", "Cart");  // assuming Cart as controller name and Index as action name
            
        return View();
    }
