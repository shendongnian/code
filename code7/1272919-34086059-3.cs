    public Product NewlyAddedProduct{get;private set;} //public property of Window
    public void SaveProduct()
    {
      var product = new Product();
      Database.Save(product);
      NewlyAddedProduct = product;
    }
