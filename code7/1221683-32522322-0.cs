    public ActionResult Product_Search(.....)
    {
      // filter your collection
      var incomplete_products = ....
      ProductCollectionVM model = new ProductCollectionVM()
      {
        List_ProductCollection = incomplete_products;
      };
      return View(model)
    }
