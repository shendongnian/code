       Task task = Task.Factory.StartNew(MethodThatThrowsException)
                        .ContinueWith(t => { throw t.Exception; }, token, TaskContinuationOptions.OnlyOnFaulted, scheduler)
                        .ContinueWith(w => Vm.StatusMessage.StopProgressBar(), token, TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
   
       System.Exception yourException = task.Exception;
