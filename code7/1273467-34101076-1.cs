    const int chunkSize = 100000;
    int result = int.MaxValue;
    object foundLock = new object();
    for (int chunk = 1; chunk < int.MaxValue; chunk += chunkSize)
    {
        Parallel.For(chunk, chunk + chunkSize, (i) =>
          {
              var hashBytes = md5Hash.Value.ComputeHash(Encoding.UTF8.GetBytes(input + i));
              if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] == 0)
              {
                  lock (foundLock)
                  {
                      result = Math.Min(result, i);
                  }
              }
          });
    
        if (result < int.MaxValue)
        {
            Console.WriteLine(result + ": " + sw.Elapsed);
            break;
        }
    }
    
