            var cts1 = new CancellationTokenSource();
            var t1 = Task
                .Factory
                .StartNew(() =>
                {
                    cts1.Cancel();
                    cts1.Token.ThrowIfCancellationRequested();
                }, cts1.Token)
                // this continuation will be fired
                .ContinueWith(t => Console.WriteLine("t1 was cancelled"), TaskContinuationOptions.OnlyOnCanceled);
