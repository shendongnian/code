    public IQueryable<Product> GetProducts(
                         [QueryString("id")] int? categoryId,
                         [RouteData] string categoryName)
    {
        var _db = new products.Models.ProductContext();
        IQueryable<Product> query = _db.Products;
        query = query.Where(p => p.Active == 1); // the first question
        if (categoryId.HasValue && categoryId > 0)
        {
            query = query.Where(p => p.CategoryID == categoryId);
        }
        if (!String.IsNullOrEmpty(categoryName))
        {
            query = query.Where(p =>
                                String.Compare(p.Category.CategoryName,
                                categoryName) == 0);
        }
        return query;
    }
