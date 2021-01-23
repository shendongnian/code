        public static Task<Int32> LongIOAsync()
        {
            Console.WriteLine("In LongIOAsync start... {0} {1}", (DateTime.Now.Ticks - ticks) / TimeSpan.TicksPerMillisecond, Thread.CurrentThread.ManagedThreadId);
            var tcs = new TaskCompletionSource<Int32>();
            Task.Run ( () => BeginLongIO(() =>
            {
                try { tcs.TrySetResult(EndLongIO()); }
                catch (Exception exc) { tcs.TrySetException(exc); }
            }));
            Console.WriteLine("In LongIOAsync end... \t{0} {1}", (DateTime.Now.Ticks - ticks) / TimeSpan.TicksPerMillisecond, Thread.CurrentThread.ManagedThreadId);
            return tcs.Task;
        }
