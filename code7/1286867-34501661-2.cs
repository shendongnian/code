    public async Task<IEnumerable<ProductItemViewModel>> GetAsync(int pageIndex, int pageSize)
    {
        var result = await this.Repository.GetAll<Product>()
            .OrderBy(p => p.Price)
            .ToPaginatedList(pageIndex, pageSize)
            .ToListAsync();
        if (result.Count == 0)
        {
            // This "if" really isn't necessary, as your mapper should map an
            // empty collection to an empty collection. But it is a minor
            // efficiency improvement, and it speaks to your original code.
            return Enumerable.Empty<ProductItemViewModel>();
        }
        var viewModels = new List<ProductItemViewModel>();
        Mapper.Map(result, viewModels);
        return viewModels; // AsEnumerable() has no effect here, as the cast will happen by
                           // default anyway
    }
