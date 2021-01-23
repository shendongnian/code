    public void UpdateProduct(CommonLayer.PRODUCT product, CommonLayer.DBModelEntities context)
    {
      CommonLayer.PRODUCT ExistingProduct = this.GetProduct(product.ProductId);
      context.Entry(ExistingProduct).CurrentValues.SetValues(product);
    }
