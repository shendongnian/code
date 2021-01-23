    [HttpPost]
    public ActionResult UpdateQuantity(int cartId, int productId, int quantity)
    {
        var cart = db.Carts.FirstOrDefault(c => c.CartId == cartId);
        cart.Count = quantity;
        
        db.SaveChanges();
        return RedirectToAction("MyCart", routeValues: new { cartId = cartId });
    }
    [HttpGet]
    public ActionResult MyCart(int cartId)
    {
        var cart = db.Carts.FirstOrDefault(c = c.CartId == cartId);
        return View(cart);
    }
