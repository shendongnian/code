    public async Task Run(CancellationToken cancellationToken)
    {
      HashSet<Task> tasks = new HashSet<Task>();
      foreach (var work in this.GetWorkNotPictured)
      {
        tasks.Add(Task.Run(() => this.DoWork(work, cancellationToken))
      }
      try
      {
        await Task.WhenAll(tasks);
      }
      finally
      {
        this.CleanUpAfterWork();
      }
    }
