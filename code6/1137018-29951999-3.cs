            var cts2 = new CancellationTokenSource();
            var t2 = Task
                .Factory
                .StartNew(() =>
                {
                    cts2.Cancel();
                    cts2.Token.ThrowIfCancellationRequested();
                })
                // this continuation will **not** be fired
                .ContinueWith(t => Console.WriteLine("t2 was cancelled"), TaskContinuationOptions.OnlyOnCanceled);
