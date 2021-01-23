    public async Task GetUSDBitcoinPrice()
    {
        var priceEstimationManager = new PriceEstimationManager(new RESTClientFactory());
        var estimatedPrice = await priceEstimationManager.GetPrices(new List<CurrencySymbol> { CurrencySymbol.Bitcoin }, "USD");
        Console.WriteLine($"Estimate: {estimatedPrice.Result.First().FiatEstimate}");
    }
