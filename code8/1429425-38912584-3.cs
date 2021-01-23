    static void Main(string[] args)
            {
              //Log.Info("Synchronous write");
              var task = Log.InfoAsync(DateTime.Now.ToString(CultureInfo.InvariantCulture));
              task.WaitAndUnwrapException();
              // or
              // task.Wait();
              // Now the application won't finish before the async method is done.
            }
