    public IEnumerable<Product> GetCategoryProducts(long categoryId)
    {
        using (var context = new MyContext())
        {
             var products = context.Categories
                                   .Include(c => c.ProductsCategoriesLinks.Select(pcl => pcl.Product))
                                   .FirstOrDefault(c => c.CategoryId == categoryId);
    
             return products;
        }
    }
