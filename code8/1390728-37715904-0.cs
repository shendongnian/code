    public static List<Product> getProducts(string hint)
    {
        List<Product> products = new List<Product>();
        using (var db = new AppDB())
        {
            try
            {
                products = db.Products.Where(p => RemoveSpecialChars(p.Description).Contains(RemoveSpecialChars(hint))).ToList();
            }
            catch
            { }
        }
        return products;
    }
