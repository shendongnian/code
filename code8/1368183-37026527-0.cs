    public ActionResult Create()
    {
         // productRepository is injected
         List<Product> products = productRepository.GetAll();
         
         return View(products);
    }
