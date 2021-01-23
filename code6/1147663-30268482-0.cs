    public void AddRandomTask()
    {
      Task t = ProcessAsync();
      Tasks.Add(t);       
      Msg.Add("Task is added");
    }
    private async Task ProcessAsync()
    {
      await Randomizer.Instance.LongRandAsync(new MainViewModelObserver(this));
      string s = "done: " + DateTime.Now.ToString("HH:mm:ss");
      this.Msg.Add(s);
    }
