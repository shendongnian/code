    [HttpPost]
    public ActionResult Index(ShoppingCartViewModel model)
    {
        foreach (var item in model.CartItems)
        {
            var productId = item.Id;
            // to do  : Use productId and do something
        }
        return RedirectToAction("OrderSucessful");
    }
