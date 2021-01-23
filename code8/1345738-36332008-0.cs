    public ICollection<T> GetProductsByMatching<T>(Expression<Func<Product, bool>> predicate)
    {
        return context.Products.Where(predicate)
                               .Include("ShopPlace, Images")
                               .ProjectTo<T>()
                               .ToList();
    }
