        var task1 = Task.Run(() =>
                               { throw new CustomException("task1 faulted.");
        }).ContinueWith(t => { Console.WriteLine("{0}: {1}",
            t.Exception.InnerException.GetType().Name,
            t.Exception.InnerException.Message);
        }, TaskContinuationOptions.OnlyOnFaulted);
