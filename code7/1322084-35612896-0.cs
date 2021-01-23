    public Product AddProduct(Product product)
    {
      using( var context = new DbContext() )
      {
        context.Add(product);
        context.SaveChanges();
      }
       return product;
    }
