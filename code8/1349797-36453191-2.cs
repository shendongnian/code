    try
    {
        byte[] result = AnyMethod();
    }catch(MyCustomException ex)
    {
        // here you can access all properties of this exception, you could also add new properties
        Console.WriteLine(ex.Message);
    }
    catch(Exception otherEx)
    {
        // all other exceptions, do something useful like logging here
        throw;  // better than throw otherEx since it keeps the original stacktrace 
    }
