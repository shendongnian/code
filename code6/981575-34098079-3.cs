    // Warning: bad code!
    class MyService
    {
      public int CalculateMandelbrot()
      {
        // Tons of work to do in here!
        for (int i = 0; i != 10000000; ++i)
          ;
        return 42;
      }
    
      public Task<int> CalculateMandelbrotAsync()
      {
        return Task.Run(() => CalculateMandelbrot());
      }
    }
