    private readonly static Task<List<string>> loadLinesTask = LoadingLines();
    public static async Task<List<string>> GetLinesAsync()
    {
        return await _loadLinesTask.ConfigureAwait(false);
    }
