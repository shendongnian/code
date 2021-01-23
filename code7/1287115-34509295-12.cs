    try
    {
        new Temp().ConditionalThrow(t => true, typeof(MyException), "Alberto", "25");
    }
    catch (MyException ex)
    {
        Console.WriteLine(ex.Message);
    }
    try
    {
        new Temp().ConditionalThrow(t => true, typeof(MyException));
    }
    catch (MyException ex)
    {
        Console.WriteLine(ex.Message);
    }      
    try
    {
        new Temp().ConditionalThrow(t => true, typeof(string));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
