    public async Task<IEnumerable<Asset>> GetAll()
    {
        var assets = _context.Books.AsEnumerable();
        return assets;
    }
