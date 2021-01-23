    public static async Task<IActionResult> Run(
               [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
               [CosmosDB(databaseName:"dbName",
                         collectionName:"collectionName",
                         ConnectionStringSetting = "CosmosDBConnection")] DocumentClient documentClient, 
               ILogger log){
                 .....
               }
        
