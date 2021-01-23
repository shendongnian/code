       public async Task<Brand> GetAsync(Guid brandId)
        {
            return await _brands.Active().Where(row => row.Id == brandId).FirstOrDefaultAsync();
        }
     public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _brands.Active().ToListAsync();
        }
