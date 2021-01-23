    static void ThrowNow(Exception ex)
    {
        throw ex;
    }
    static async Task TestExAsync()
    {
        ThrowNow(new System.Exception("Testing"));
        await Task.Delay(1000);
    }
    static void Main()
    {
        var task = TestExAsync();
        Console.WriteLine(task.Exception);
    }
