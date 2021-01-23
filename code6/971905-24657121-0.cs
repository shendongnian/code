    try
    {
      // blocks the current thread until the source finishes
      var result = source.Wait(); 
      Console.WriteLine("result=" + result);
    }
    catch (Exception err)
    {
      Console.WriteLine("uh oh", err);
    }
