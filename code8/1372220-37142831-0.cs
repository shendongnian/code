      var stopwatch = new Stopwatch();
      var random = new Random();
      var numberOfValues = 1000000;
      var repetitions = 100;
      var quotients = new double[numberOfValues];
      var sineValues = new double[numberOfValues];
      var results = new double[numberOfValues];
      // Preparing values for the measurement.
      for (var i = 0; i < numberOfValues; i++)
      {
        quotients[i] = random.NextDouble() / random.NextDouble();
        sineValues[i] = Math.Sin(quotients[i]);
      }
      
      // First method: Squaring and taking square root.
      stopwatch.Start();
      for (var j = 0; j < repetitions; j++)
      {
        for (var i = 0; i < numberOfValues; i++)
        {
          results[i] = Math.Sqrt(1 - Math.Pow(sineValues[i], 2));
        }
      }
      stopwatch.Stop();
      Console.WriteLine(stopwatch.Elapsed);
      stopwatch.Reset();
      // Second method: Arcsine and cosine.
      stopwatch.Start();
      for (var j = 0; j < repetitions; j++)
      {
        for (var i = 0; i < numberOfValues; i++)
        {
          results[i] = Math.Cos(Math.Asin(quotients[i]));
        }
      }
      stopwatch.Stop();
      Console.WriteLine(stopwatch.Elapsed);
