    public IEnumerable<Asset> GetAlls()
    {
        var assets = _context.Books;
        return assets;
    }
