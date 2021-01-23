    try
    {
          using (var streamWriter = new StreamWriter(filename, true))
          {
                 streamWriter.WriteLine("I am working!");
          }
    }
    catch { ... }
