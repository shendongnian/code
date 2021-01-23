    private async void Button_Clicked(object sender, EventArgs e)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      Task taskA = ExecuteTaskAAsync();
      Task taskB = ExecuteTaskBAsync();
      await Task.WhenAll(taskA, taskB);
      watch.Stop();
      System.Diagnostics.Debug.WriteLine("Seconds Elapsed: " + watch.Elapsed.Seconds);
    }
    private async Task ExecuteTaskAAsync()
    {
      for (int i = 0; i < 10; i++)
      {
        System.Diagnostics.Debug.WriteLine("Task A: [{0}]", i + 1);
        await Task.Delay(1000);
      }
      System.Diagnostics.Debug.WriteLine("Finished Task A!");
    }
    private async Task ExecuteTaskBAsync()
    {
      for (int i = 0; i < 10; i++)
      {
        System.Diagnostics.Debug.WriteLine("Task B: [{0}]", i + 1);
        await Task.Delay(1000);
      }
      System.Diagnostics.Debug.WriteLine("Finished Task B!");
    }
