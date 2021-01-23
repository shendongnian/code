     catch (FaultException ex)
     {
       proxy.Abort();
       Console.WriteLine("{0:00000}: Client chatched [{1}]", stopwatch.ElapsedMilliseconds,
                                ex.GetType().Name);
     }
