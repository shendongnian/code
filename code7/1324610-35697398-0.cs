    public class Parallel
    {
        public static void ForEach<T>(IEnumerable<T> items, Action<T> action)
        {
            var resetEvents = new List<ManualResetEvent>();
    
            foreach (var item in items)
            {
                var evt = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem((i) =>
                {
                    action((T)i);
                    evt.Set();
                }, item);
                resetEvents.Add(evt);
            }
    
            foreach (var re in resetEvents)
                re.WaitOne();
        }
    }
