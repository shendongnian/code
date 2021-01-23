    public static async Task ProcessStagedOperation(StagedOperation operation, int i)
    {
        await operation.Connect;
        Console.WriteLine("{0}: Connected", i);
        await operation.Accept;
        Console.WriteLine("{0}: Accepted", i);
        await operation.Complete;
        Console.WriteLine("{0}: Completed", i);
    }
