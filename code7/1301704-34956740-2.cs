    public class BackgroundJobSchedueller
    {
        readonly BlockingCollection<Action> _queue;
        readonly Thread _thread;
        
        public BackgroundJobSchedueller()
        {
            _queue = new BlockingCollection<Action>()
            _thread = new Thread(WorkThread)
            {
                IsBackground = true,
                Name = "Background Queue Processor"
            };
            _thread.Start();
        }
    
        public void StopSchedueller()
        {
            //Tell GetConsumingEnumerable() to let the user out of the foreach loop
            // once the collection is empty.
            _queue.CompleteAdding();
            //Wait for the foreach loop to finish processing.
            _thread.Join();
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
