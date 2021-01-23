    public async Task ProcessStagedOperation(StagedOperation op, int i)
    {
        await op.Connect;
        Console.WriteLine("{0}: Connected", i);
        await op.Accept;
        Console.WriteLine("{0}: Accepted", i)
        await op.Complete;
        Console.WriteLine("{0}: Completed", i)
    }
