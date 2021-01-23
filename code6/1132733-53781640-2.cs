    [TestMethod]
    public void ConcurrentMapLazyTask() {
      Func<Task> Get = async () => {
        Trace.WriteLine("Start task.");
        await Task.Delay(200);
        Trace.WriteLine("End task.");
      };
      Action<Task> Complete = (t) => {
        Trace.WriteLine("Complete.");
      };
      var mp = new ConcurrentDictionary<string, Lazy<Task>>();
      Func<string, Lazy<Task>> valueFactory = (sKey) => {
        var s = Guid.NewGuid().ToString();
        Trace.WriteLine(string.Format("valueFactory called => {0}", s));
        return new Lazy<Task>(() => {
          Trace.WriteLine(string.Format("LazyTask factory called for {0}", s));
          var t = Task.Run(async () => {
            Trace.WriteLine(string.Format("Task.Run executed for {0}", s));
            await Get();
          });
          return Task.WhenAll(t, t.ContinueWith(Complete));
        });
      };
      Func<Task> TestAsync = async () => {
        var lazyTask = mp.GetOrAdd("test", valueFactory);
        await lazyTask.Value;
      };
      Action TestSync = () => {
        TestAsync().Wait();
        Trace.WriteLine("End test.");
      };
      Action TestSyncSlow = () => {
        Thread.Sleep(50);
        TestAsync().Wait();
        Trace.WriteLine("End slow test.");
      };
      //Parallel.Invoke(TestSync);
      Parallel.Invoke(TestSync, TestSyncSlow, TestSync, TestSync);
    }
