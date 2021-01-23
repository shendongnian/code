    private static string stringTest()
    {
        return getStringAsync().Result;
    }
    private static async Task<string> getStringAsync()
    {
        return await Task.FromResult<string>("Hello");
    }
    static void Main(string[] args)
    {
        Console.WriteLine(stringTest());
    
    }
