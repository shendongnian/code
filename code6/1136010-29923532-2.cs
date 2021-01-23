    var s = Observable.Defer(()=>Observable.Return(nextMsg()))
                      .Delay(TimeSpan.FromSeconds(2))
                      .Repeat(100)
                      .Finally(() => job.AddMessage<ProgressCompleted>(ProgressManager.CompletedMessage("Completed")))
                      .SubscribeOn(Scheduler.ThreadPool)
                      .Subscribe(m => job.AddMessage(m));
