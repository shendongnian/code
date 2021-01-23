    try
    {
        doSomethingElse()
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Personalized message #1");               
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Personalized message #2");               
    }
    catch (Exception)
    {
        Console.WriteLine("Personalized message #3");               
    }
