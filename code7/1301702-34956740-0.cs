    public class BackgroundJobSchedueller
    {
        readonly BlockingCollection<Action> _queue;
        
        public BackgroundJobSchedueller()
        {
            _queue = new BlockingCollection<Action>()
            var t = new Thread(WorkThread)
            {
                IsBackground = true,
                Name = "Background Queue Processor"
            };
            t.Start();
        }
    
        public void StopSchedueller()
        {
            _queue.CompleteAdding();
        }
    
        public void QueueJob(Action job)
        {
            _queue.Add(job);
        }
    
        void WorkThread()
        {
            foreach(var action in _queue.GetConsumingEnumerable())
            {
                try
                {
                    action();
                }
                catch
                {
                    //Do something with the exception here
                }
            }
        }
    }
