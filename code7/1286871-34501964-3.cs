    public async Task<IEnumerable<ProductItemViewModel>> GetAsync(int pageIndex, int pageSize)
    {
       
        return await this.Repository.GetAll<Product>()
                                    .OrderBy(p => p.Price)
                                    .Skip(pageIndex*pageSize)
                                    .Take(pageSize)
                                    .ProjectTo<ProductItemViewModel>()
                                    .ToListAsync();
    }
