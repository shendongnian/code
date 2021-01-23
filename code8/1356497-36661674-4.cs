    [HttpGet]
    public ViewResult ProductDetails(int productId)
    {
        Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
        string[] sizes = product.AvailableSizes.Split(',');
        ProductVM model = new ProductVM()
        {
            ID = product.ProductId,
            Name = product.Name
            AvailableSizes = new SelectList(sizes),
            ReturnUrl = ....
        };
        return View(model);
    }
