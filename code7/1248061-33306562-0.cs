    public async Task CreateProductAsync(int id)
    {
        Product result = factory.Create(id);
        await AssignPricesAsync(result);
        Assert.That(result.Prices.Count == 1);
    }
