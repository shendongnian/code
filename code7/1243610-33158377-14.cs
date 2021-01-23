            Task task = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();  // <-- NOTICE
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token).ContinueWith((t) =>
            {
                Console.WriteLine("From Continuation: " + t.Status);
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);
    // OUTPUT:
    // ***
    // From Continuation: Canceled
    // You have canceled the task
