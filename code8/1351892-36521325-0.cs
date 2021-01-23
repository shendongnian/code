    public Task<IEnumerable<Asset>> GetAll()
    {
        var assets = Task.Factory.StartNew(() => (IEnumerable<Asset>) _context.Books);
        return assets;
       // tried  toList<asset>() on "return assets" as well but didnt make any difference.
    }
    public IEnumerable<Asset> GetAlls()
    {
        var assets = _context.Books;
        return assets;
    }
