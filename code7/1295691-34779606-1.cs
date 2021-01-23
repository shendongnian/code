    try
    {
        using (var result = await Task.Run(() => (IConnection)Factory.GetObject(typeof(IConnection))).TimeoutAfter(1000))
        {
            ...
        }
    }
    catch (TimeoutException ex)
    {
        //timeout
    }
