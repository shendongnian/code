    public object Get(  [FromUri] string[] categories)
    {
        var categories = db.Categories.Where(c => categoriesIds.Contains(c.Id));
        Func<Product, bool> filters = p => 1==1
              && p.Price >= minPrice && p.Price <=maxPrice 
        return GetCategoryiesProducts(categories, filters)
    }
    public IList<Product> GetCategoryiesProducts(IList<Category> categories, Func<Product, bool> filters)
    {
        var result = new List<Product>();
        foreach (var c in categories) 
        {
            result.AddRange(c.Products.Where(filters).ToList());
            var subCategories = db.Categories.Where(s => s.ParentCategoryID != null && (int)s.ParentCategoryID == c.Id))
            if (subCategories != null && subCategories.Count > 0)
            {
                 result.AddRange(GetCategoryiesProducts(subCategories, filters))
            }
        }
        List<Product> search_results result;
    }
