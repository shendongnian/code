    public Product GetProductById(int productId)
    {
      Product p = null;
    
      using (ADOCRUDContext context = new ADOCRUDContext(connectionString))
      {
        p = context.QueryItems<Product>("select * from dbo.Product where Id = @id", new { id = productId }).FirstOrDefault();
      }
    
      return p;
    }
    
    public void UpdateProduct(int productId)
    {
      //see the second argument
      using (ADOCRUDContext context = new ADOCRUDContext(connectionString, Options.ReuseExisting))
      {
        Product p = this.GetProductById(productId);
        p.Name = "Basketball";
        context.Update<Product>(p);
        context.Commit();
      }
    }
