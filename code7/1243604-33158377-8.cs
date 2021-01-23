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
                Console.WriteLine("You have NOT canceled the task");
            });
    // OUTPUT:
    // ***
    // From Continuation: RanToCompletion
    // You have NOT canceled the task
    // (no AggregationException thrown)
