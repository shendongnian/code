    public Task<IEnumerable<Asset>> GetAll()
    {
        var assets = Task.Factory.StartNew(() => (IEnumerable<Asset>) _context.Books);
        return assets;
    }
    public IEnumerable<Asset> GetAlls()
    {
        var assets = _context.Books;
        return assets;
    }
