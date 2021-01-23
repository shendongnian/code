    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
    {
        string path = context.FunctionDirectory;
        string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
        SqlServerTypes.Utilities.LoadNativeAssemblies(newPath);
