    public async Task<IEnumerable<Product>> GetProductByYearIdAsync(int yearId)
    {
        return await ApplicationsContext.Product
            .Where(product=> product.YearId == yearId).ToListAsync();
    }
