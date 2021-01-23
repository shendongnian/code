    public async Task<IList<IFoo>> GetList()
    {
        List<Foo> results = await database.GetCollection<Foo>("Foo").Find(_ => true).ToListAsync();
        return results.Cast<IFoo>().ToList();
    }
