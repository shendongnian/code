    public class ThreadRegistry
    {
        private readonly IDictionary<string, Thread> threads = new Dictionary<string, Thread>();
        private readonly object syncRoot = new object();
        public void Register(Thread thread)
        {
           lock (this.syncRoot)
           {
              this.threads.Add(thread.Name, thread);
           }
        }
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
    }
