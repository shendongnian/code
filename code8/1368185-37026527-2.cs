    public ActionResult Create()
    {
         ProductViewModel productViewModel = new ProductViewModel();
         productViewModel.Products = productRepository.GetAll();
         productViewModel.Department = "Test Department Name";
         
         return View(productViewModel);
    }
