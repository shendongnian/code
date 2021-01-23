    // Create a stopwatch for performance testing
    var stopwatch = new Stopwatch();
     // Test content
    var data = GetTestingBytes();
    // Looping Test
    using (var loop = new MemoryStream())
    {
          stopwatch.Start();
          foreach (var item in data)
          {
                loop.WriteByte(item);
          }
          stopwatch.Stop();
          Console.WriteLine($"Loop Test: {stopwatch.Elapsed}");
    }
    // Buffered Test
    using (var buffer = new MemoryStream())
    {
          stopwatch.Start();
          buffer.Write(data, 0, data.Length);
          stopwatch.Stop();
          Console.WriteLine($"Buffer Test: {stopwatch.Elapsed}");
    }
