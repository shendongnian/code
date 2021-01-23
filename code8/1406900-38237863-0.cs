        cancellationTokenSource.CancelAfter(5000);
        Task registerTask = Task.Factory.StartNew(() =>
        {
          btr = builder.Register();
        });
       Task cancellationTask = Task.Factory.StartNew(() =>
       {
         while (true)
         {
           if (cancellationTokenSource.Token.IsCancellationRequested) break;
         }
         }, cancellationTokenSource.Token);
       Task[] tasks = new Task[2] { cancellationTask, registerTask };
       Task.WaitAny(tasks);
