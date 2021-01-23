    using (var db = new EntityDataModel())
    {
        var node = db.Tree.FirstOrDefault(x => x.Guid == editedNode);
        List<long> descentantIds = db.Tree
                   .Where(x => x.AncestorID == node.AncestorID)
                   .Select(x => x.DescendantID)
                   .ToList();
        List<Product> method1 = db.Products
            .SelectMany(x => x.ProductsInCategories.Where(c => descentantIds.Contains(c.ProductCategoryID))).Select(c => c.Product).Distinct()
            .Include(c => c.Assets.Select(c1 => c1.Translations.Select(c2 => c2.Language)))
            .Include(c => c.Tags.Select(c1 => c1.Translations.Select(c2 => c2.Language)))
            .Include(c => c.Details)
            .Include(c => c.Prices.Select(c1 => c1.Currency))
            .Include(c => c.Prices.Select(c1 => c1.Seller))
            .Include(c => c.Translations.Select(c1 => c1.Language))
            .Include(c => c.ProductsInCategories)
            .ToList();
        var method2 = (from product in db.Products
                     join productsInCategories in db.ProductsInCategories
                     on product.ID equals productsInCategories.ProductID
                     join productsCategories in db.ProductsCategories
                     on productsInCategories.ProductCategoryID equals productsCategories.ID
                     where descentantIds.Contains(productsInCategories.ProductCategoryID)
                     select product)
                     .Include(c => c.Assets.Select(c1 => c1.Translations.Select(c2 => c2.Language)))
                     .Include(c => c.Tags.Select(c1 => c1.Translations.Select(c2 => c2.Language)))
                     .Include(c => c.Details)
                     .Include(c => c.Prices.Select(c1 => c1.Currency))
                     .Include(c => c.Prices.Select(c1 => c1.Seller))
                     .Include(c => c.Translations.Select(c1 => c1.Language))
                     .Include(c => c.ProductsInCategories);
        var result = method2.ToList<Product>();
    }
