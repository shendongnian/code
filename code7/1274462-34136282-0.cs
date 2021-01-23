    public static void Main()
    {
        Console.WriteLine(DoSomethingAsync().IsCanceled);
    }
    private static async Task DoSomethingAsync()
    {    
        throw new OperationCanceledException();
    }
