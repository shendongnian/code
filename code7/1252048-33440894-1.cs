    public class ThreadRegistry
    {
       private static ThreadRegistry instance;
       private readonly object syncRoot = new object();
       private readonly IDictionary<string, Thread> threads = new Dictionary<string, Thread>();
       private ThreadRegistry()
       {
       }
       public static ThreadRegistry Instance => instance ?? (instance = new ThreadRegistry());
       public Thread this[string name]
       {
          get
          {
             lock (this.syncRoot)
             {
                return this.threads[name];
             }
          }
       }
       public void Register(Thread thread)
       {
          lock (this.syncRoot)
          {
             this.threads.Add(thread.Name, thread);
          }
       }
       public bool ThreadExists(string name)
       {
          lock(this.syncRoot)
          {
             return this.threads.ContainsKey(name);
          }
       }
    }
