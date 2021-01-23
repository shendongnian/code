    static void Main(string[] args)
    {
      var items = Enumerable.Range(1, 2);
      Console.WriteLine("Start");
      var tasks = items.Select(i => AsyncMethod(i)).ToArray();
      Console.WriteLine("Got tasks");
      Task.WaitAll(tasks);
      Console.WriteLine("Done!");
    }
    static async Task AsyncMethod(int i)
    {
      Console.WriteLine("Enter {0}", i);
      await AsyncMethod2(i);
      await Task.Delay(1000);
      Console.WriteLine("Exit {0}", i);
    }
    static async Task AsyncMethod2(int i)
    {
      Console.WriteLine("Enter2 {0}", i);
      await Task.Delay(2000);
      Console.WriteLine("Exit2 {0}", i);
    }
