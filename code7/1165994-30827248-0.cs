    using (TaskService ts = new TaskService())
    {
      Task t = ts.GetTask(taskName);
      if (t != null)
      {
          // get status here or get runtime
          var isEnabled = t.Enabled;
          var runs = t.GetRunTimes(startDate,endDate);
      }
    }
