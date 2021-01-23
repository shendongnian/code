    try
    {
        new Temp().ConditionalThrow(t => true, () => new MyException("Alberto", "25"));
    }
    catch (MyException ex)
    {
        Console.WriteLine(ex.Message);
    }
    try
    {
        new Temp().ConditionalThrow(t => true, () => new MyException());
    }
    catch (MyException ex)
    {
        Console.WriteLine(ex.Message);
    }
