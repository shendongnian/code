    public IQueryable<ProductDTO> Get()
    {
        var products = from p in db.Products
            select new ProductDTO()
            {
                Id = p.Id,
                Created = p.Created,
                Title = p.Title,
                CustomValue = p.Id == 1 || p.Id == 2 ? 1 : p.Id == 3 ? 2 :0;
            };
        return products.AsQueryable();
    }
