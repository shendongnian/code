    var o = Observable.Return(ProgressManager.InProgressMessage("progressing"))
                              .Repeat()
                              .Timeout(TimeSpan.FromSeconds(2))
                              .Retry(100)
                              .Finally(() => job.AddMessage<ProgressCompleted>(ProgressManager.CompletedMessage("Completed")));
    var s = o.Subscribe(m => job.AddMessage(ProgressManager.InProgressMessage("progressing")));
