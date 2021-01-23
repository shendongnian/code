    public List<Product> ListAllProducts(Func<DbContext> dbFunc)
    {
        using(MyDbContext usingDb = dbFunc())
        {
            // ...
        }
    }
