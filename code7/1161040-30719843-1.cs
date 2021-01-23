    try
    {
        await Copy(@"c:\temp\test2.bin", @"c:\temp\test.bin", 60);
        Console.WriteLine("finished..");
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine("cancelled..");
    }
    catch (Exception ex)
    {
        Console.WriteLine("error..");
    }
