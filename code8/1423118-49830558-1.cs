    [FunctionName("ProductUpsertHttpTrigger")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "products")] 
        HttpRequestMessage req,
        [DocumentDB(
        databaseName: "%CosmosDbDdatabaseName%",
        collectionName: "%CosmosDbCollectionName%")] IAsyncCollector<Product> collector,
        TraceWriter log)
    ...
