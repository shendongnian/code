    private static void Main(string[] args)
    {
      var tskList = new List<Task>();
      for (var i = 0; i < 100; i++)
      {
        var i1 = i;
        var taskTemp = new Task(() => { Display(i1); });
        taskTemp.Start();
        tskList.Add(taskTemp);
      }
      Task.WaitAll(tskList.ToArray());
    }
    
    public static void Display(int value)
    {
      Thread.Sleep(1000);
      Console.WriteLine(value);
    }
