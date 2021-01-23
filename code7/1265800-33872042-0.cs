    public async Task FirstTask() 
    {
      Console.WriteLine("Start First task");
      await Task.Delay(TimeSpan.FromSeconds(2));
      Console.WriteLine("End Firt task");
    }
    public async Task SecondTask()
    {
      Console.WriteLine("Start Second task");
      await Task.Delay(TimeSpan.FromSeconds(3));
      Console.WriteLine("End Second task");
    }
    public async Task ThirdTask()
    {
      Console.WriteLine("Start Third task");
      await Task.Delay(TimeSpan.FromSeconds(2));
      Console.WriteLine("End Third task");
    }
