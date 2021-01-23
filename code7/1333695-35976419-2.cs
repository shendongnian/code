    public HttpResponseMessage GetAllProducts(int page, string sortColumn, string name = null)
    {
        const int PageSize = 4;
        IQueryable<Product> query = db.Products;
        if (!string.IsNullOrEmpty(Name))
        {
            query = query.Where(p => p.Name.StartsWith(name));
        }
        int numberOfRecords = result.Count();
        var begin = (page - 1) * PageSize;
        var data = query.Skip(begin).Take(PageSize)
            .OrderBy(sortColumn)
            .ToList();
        ProductPager myproduct = new ProductPager
        {
            ProductList = data,
            TotalRecords = numberOfRecords 
        };
        return Request.CreateResponse(HttpStatusCode.OK, myproduct);
    }
