    Func<Task> action = async () =>
    {
        Console.WriteLine("Action start...");
        await Task.Delay(1000);
        throw new Exception("Exception from an async action");
    };
    
    try
    {
       await Task.Run(action);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.ReadKey(); 
