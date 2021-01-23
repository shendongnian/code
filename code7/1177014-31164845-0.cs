    /// <summary>
    /// Producer/consumer queue. Used when a task needs executing, it’s enqueued to ensure order, 
    /// allowing the caller to get on with other things. The number of consumers can be defined, 
    /// each running on a thread pool task thread. 
    /// Adapted from: http://www.albahari.com/threading/part5.aspx#_BlockingCollectionT
    /// </summary>
    public class ProducerConsumerQueue : IDisposable
    {
        private BlockingCollection<Action> _taskQ = new BlockingCollection<Action>();
    
        public ProducerConsumerQueue(int workerCount)
        {
            // Create and start a separate Task for each consumer:
            for (int i = 0; i < workerCount; i++)
            {
                Task.Factory.StartNew(Consume);
            }
        }
    
        public void Dispose() 
        { 
            _taskQ.CompleteAdding(); 
        }
    
        public void EnqueueTask(Action action) 
        { 
            _taskQ.Add(action); 
        }
    
        private void Consume()
        {
            // This sequence that we’re enumerating will block when no elements
            // are available and will end when CompleteAdding is called.
            // Note: This removes AND returns items from the collection.
            foreach (Action action in _taskQ.GetConsumingEnumerable())
            {
                // Perform task.
                action();
            }
        }
    }
