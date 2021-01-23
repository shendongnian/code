    public static IEnumerable<Product> SearchArrayQueryLinq(IEnumerable<string> names)
    {
        using (var session = Database.OpenSession())
        {
            var products = session.Query<Product>();
            return result = products.ToList().Where(product => names.Any(name =>  product.Name.Contains(name)));
        }
    }
