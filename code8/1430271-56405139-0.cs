    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/jsontestapi")] HttpRequest req,
        ILogger log)
    {
        return new JsonResult(resultObject);
    }
