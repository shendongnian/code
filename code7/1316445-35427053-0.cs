    try
    {
        var obj = new SomeIDisposableObject;
        // ...
    }
    catch (exception ex)
    {
    }
    finally
    {
        obj.Dispose();
    }
