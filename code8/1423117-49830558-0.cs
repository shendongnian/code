    public static class UpsertProductCosmosDbTrigger
    {
        [FunctionName("ProductUpsertCosmosDbTrigger")]
        public static void Run(
            [CosmosDBTrigger(
            // Those names come from the application settings.
            // Those names can come with both preceding % and trailing %.
            databaseName: "CosmosDbDdatabaseName",
            collectionName: "CosmosDbCollectionName",
            LeaseDatabaseName = "CosmosDbDdatabaseName",
            LeaseCollectionName = "CosmosDbLeaseCollectionName")] 
            IReadOnlyList<Document> input,
            TraceWriter log)
    ...
