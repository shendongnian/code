    public Task ProcessCustomer(Customer customer)
    {
         return Task.Factory.StartNew(() => 
         {
                try
                {
                    Parallel.ForEach(customer.Orders, parOpts, (order, loopState) =>
                    {
                        count = Interlocked.Increment(ref count);
                        ProcessOrder(order, count);
                    });
                }
                catch (OperationCanceledException)
                {
                   //omitted code
                }
         }, cancelToken.Token).ContinueWith(result => OnTaskCompleted(
         {
           //omitted code
         }), new CancellationTokenSource().Token, TaskContinuationOptions.None,
             TaskScheduler.FromCurrentSynchronizationContext());
    }
