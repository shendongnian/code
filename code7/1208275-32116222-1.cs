    static void Test1()
    {
      var f = Stopwatch.Frequency;
      Point a = new Point(1, 1), b = new Point(1, 1);
    
      var sw = Stopwatch.StartNew();
      for (int i = 0; i < ITERATIONS; i++)
        a = AddByVal(a, b);
      sw.Stop();
      Console.WriteLine("Test1: x={0} y={1}, Time elapsed: {2} ms",
          a.X, a.Y, sw.ElapsedMilliseconds);
    }
