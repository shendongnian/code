            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token).ContinueWith((t) =>
            {
                Console.WriteLine("From Continuation: " + t.Status);
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);
    // OUTPUT:
    // AggregationException as you've seen
