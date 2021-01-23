    static void Main()
    {
        AsyncMain();
    }
    static async void AsyncMain()
    {
        var task = TestExAsync();
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
