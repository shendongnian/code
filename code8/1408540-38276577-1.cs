    ProductsService productsService;
    public MyController() // constructor
    {
       productsService = new ProductsService(); // Again, no Dependency Injection here for simplicity
    }
    [HttpPost]
    public PartialViewResult FilterProducts(int[] categoriesIds, decimal minPrice, decimal? maxPrice, string[] colors)
    {
         List<Product> products = productsService.FilterBy(categoriesIds, minPrice, maxPrice, colors);
         return PartialView("_LoadProducts", products);
    }
