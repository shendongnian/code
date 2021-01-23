    public async Task<IEnumerable<ProductItemViewModel>> GetAsync(int pageIndex, int pageSize)
    {
        var products = this.Repository.GetAll<Product>().OrderBy(p => p.Price).ToPaginatedList(pageIndex, pageSize);
        var result = await products.ToListAsync();
        if (result.Count == 0)
            return Enumerable.Empty<ProductItemViewModel>();
        var viewModels = new List<ProductItemViewModel>();
        Mapper.Map(result, viewModels);
        return viewModels.AsEnumerable();
    }
