       public static Task<int> LongIOAsync()
       {
            var tcs = new TaskCompletionSource<Int32>();
            Task.Run ( () => BeginLongIO(() =>
            {
                try { tcs.TrySetResult(EndLongIO()); }
                catch (Exception exc) { tcs.TrySetException(exc); }
            }));
           
            return tcs.Task;    
       }
