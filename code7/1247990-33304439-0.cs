    IEnumerable<Product> GetProducts(int? categoryId)
    {
        var result = databaseObject.Products.Where(product => ProductCategoryPredicate(product, categoryId)
    }
    
    /// <summary>
    /// Returns true if the passed in categoryId is NULL
    /// OR if it's not null, if the passed in categoryId matches that
    /// of the passed in product
    ///
    /// This method will get called once for each product returned from 
    /// databaseObject.Products</summary>
    bool ProductCategoryPredicate(Product product, int? categoryId)
    {
        if (categoryId.HasValue)
        {
            return product.Category == categoryId.Value;
        }
        else
        {
            return true;
        }
    }
