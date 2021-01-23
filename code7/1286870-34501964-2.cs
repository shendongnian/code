    using AutoMapper.QueryableExtensions;
    //...
    public async Task<IEnumerable<ProductItemViewModel>> GetAsync(int pageIndex, int pageSize)
    {
        var products = this.Repository.GetAll<Product>().OrderBy(p => p.Price);// I think you don't need to call AsQueryable(), you already are working with IQueryable
        var result=await products.Skip(pageIndex*pageSize).Take(pageSize).ProjectTo<ProductItemViewModel>().ToListAsync();
        return result;
    }
