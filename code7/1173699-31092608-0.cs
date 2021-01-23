    private static IReliableReadWriteDocumentClient CreateClient(IDocumentDbConnectionSettings connectionSettings)
    {
        return new DocumentClient(new Uri(connectionSettings.AccountEndpoint), connectionSettings.AccountKey)
            .AsReliable(new FixedInterval(10, TimeSpan.FromSeconds(1)));
    }
