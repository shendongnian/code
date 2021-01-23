    Task task = SomeAsyncMethod();
    task.Start();
    tasks.Add(task);
    ...
    OnNavigatedFrom() 
    {
       foreach (var task in tasks)
       {
          if (!task.IsCancelled && !task.IsCompleted)
              task.AsAsyncAction().Cancel();
        }
    }
    But I have not tested it and I do not guarantee this will work
               
