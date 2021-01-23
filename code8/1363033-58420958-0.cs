    public async Task<Product> GetValue(int id)
        {
            Product Products = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Products;
        }
