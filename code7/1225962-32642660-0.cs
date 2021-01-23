    public static void Main()
    {
      WaitForItAsync().Wait();
      Console.ReadLine();
    }
    static async Task WaitForItAsync()
    {
      Info theInfo = await Task.Run(() => CreateInfo());
      Console.WriteLine(theInfo.done);
      foreach (KeyValuePair<int, int> item in theInfo.results)
      {
        Console.WriteLine(item.Key + "=" + item.Value);
      }
    }
    static Info CreateInfo()
    {
      Info info = new Info();
      info.done = true;
      info.results = new Dictionary<int, int>();
      info.results.Add(1, 2);
      info.results.Add(3, 4);
      return info;
    }
