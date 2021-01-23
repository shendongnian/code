    private static SemaphoreSlim mutex = new SemaphoreSlim(10);
    public static async Task StreamToFile(Stream input, string fileName)
    {
      await mutex.WaitAsync();
      try
      {
        if (input != null)
        {
          string dir = Path.GetDirectoryName(fileName);
          if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
          using (Stream str = File.Create(fileName))
          {
            await input.CopyToAsync(str);
            input.Dispose();
          }
        }
      }
      finally
      {
        mutex.Release();
      }
    }
