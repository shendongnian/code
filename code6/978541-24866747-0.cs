    try
    {
        //do something
    }
    catch (TimeoutException t)
    {
        Console.WriteLine(t);
    }
    catch (TaskCanceledException tc)
    {
        Console.WriteLine(tc);
    }
    catch (AggregateException ae)
    {
       // This may contain multiple exceptions, which you can iterate with a foreach
       foreach (var exception in ae.InnerExceptions)
       {
           Console.WriteLine(exception.Message);
       }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
