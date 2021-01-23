    public ActionResult GetShoppingCart()
    {
        ShoppingCartActions userShoppingcart = new ShoppingCartActions();
        return View(userShoppingcart.GetCartItems());
    }
    [HttPost]
    public ActionResult GetShoppingCart(int cartID)
    {
        ShoppingCartActions userShoppingcart = new ShoppingCartActions();
        userShoppingcart.AddToCart(cartID);
        return View(userShoppingcart.GetCartItems());
    }
