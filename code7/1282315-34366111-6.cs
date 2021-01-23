    public ActionResult Index()
    {
        var cart = new ShoppingCartViewModel
        {
            CartItems = new List<Product>
            {
                new Product   { Id = 1, Name = "Iphone" },
                new Product   { Id = 3, Name = "MacBookPro" }
            },
            TotalPrice = 3234.95
        };
        return View(cart);
    }
