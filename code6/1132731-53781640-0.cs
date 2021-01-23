    public void ConcurrentMapLazyTask() {
      var mp = new ConcurrentDictionary<string, Lazy<Task<string>>>();
      Func<Task> TestAsync = async () => {
        var lazyTask = mp.GetOrAdd("test", (k) => {
          var s = Guid.NewGuid().ToString();
          Trace.WriteLine(string.Format("valueFactory=>{0}", s));
          return new Lazy<Task<string>>(() => {
            Trace.WriteLine(string.Format("LazyTask=>{0}", s));
            return Task.Run(async () => {
              Trace.WriteLine(string.Format("Task.Run=>{0}", s));
              await Task.Delay(200);
              return s;
            });
          });
        });
        Trace.WriteLine(string.Format("GetOrAdd=>{0}", await lazyTask.Value));
      };
      Action TestSync = () => {
        TestAsync().Wait();
      };
      Action TestSyncSlow = () => {
        Thread.Sleep(50);
        TestAsync().Wait();
      };
      Parallel.Invoke(TestSync, TestSyncSlow, TestSync, TestSync);
    }
