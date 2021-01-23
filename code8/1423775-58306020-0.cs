    public static async Task LongProcessAsync()
    {
        TeenyWeenyInitialization(); // Synchronous
        await SomeBuildInAsyncMethod().ConfigureAwait(false); // Asynchronous
        CalculateAndSave(); // Synchronous
    }
