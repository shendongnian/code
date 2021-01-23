    public async Task ProcessAsync()
    {
      WebJob[] jobs = CreateWebJobs();
      await Task.WhenAll(jobs.Select(x => ExecuteJobAsync(x)));
    }
    private async Task ExecuteJobAsync(WebJob job, [CallerMemberName] string memberName = "")
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("Caller> {0} :: {1} Job> {2} :: {3} Thread> {4}", memberName, "\t", job.Name, "\t", Thread.CurrentThread.ManagedThreadId);
      await GetDataAsync(job);
      if (job.Children != null)
      {
        var childTasks = job.Children.Select(async x =>
        {
          x.ParentResponse = job.Response; // Children need parent's response
          await ExecuteJobAsync(x);
        });
        await Task.WhenAll(childTasks);
      }
    }
