    public class MyClass
    {
        static int nextId;
        public int id;
        public int x;
        public MyClass()
        {
            id = Interlocked.Increment(ref nextId);
            x = (id % 4 + 1) * 250; 
        }
        public void DoWork(CancellationToken cancelToken)
        {
            bool is_canceled = false;
            while (!cancelToken.IsCancellationRequested && cycle < 5)
            {
                try
                {
                    Console.WriteLine("Task {0} waiting, tid = {1}", id, Thread.CurrentThread.ManagedThreadId);
                    Task.Delay(x / 5, cancelToken).Wait(); // don't do Thread.Sleep()
                    Console.WriteLine("Task {0} waking up, tid = {1}", id, Thread.CurrentThread.ManagedThreadId);
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerExceptions.Any(x => typeof(OperationCanceledException).IsAssignableFrom(x.GetType())))
                    {
                        Console.WriteLine("Task {0} canceled, tid = {1}", id, Thread.CurrentThread.ManagedThreadId);
                        is_canceled = true;
                        break;
                    }
                    throw;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Task {0} canceled, tid = {1}", id, Thread.CurrentThread.ManagedThreadId);
                    is_canceled = true;
                }
                cycle++;
            }
            is_canceled |= cycle < 5;
            Console.WriteLine("{0} {1}, tid = {2}", this.id, is_canceled ? "canceled" : "completed", Thread.CurrentThread.ManagedThreadId);
        }
    }
