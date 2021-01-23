    // Simplified example. Check http://www.albahari.com/threading/part2.aspx
    // for detailed explanations of this and other syncronizing constructs
    private readonly AutoResetEvent _signal = new AutoResetEvent(false);
    private readonly ConcurrentQueue<Something> _queue = new ConcurrentQueue<Something>();
    // this method can be called by one or more threads simultaneously
    // (although the order of enqueued items cannot be known if many threads are competing)
    void ProduceItem(Something s)
    {
        _queue.Enqueue(s);  // enqueue item for processing
        _signal.Set();      // signal the consumer thread if it's waiting
    }
    // this loop should be running on a separate thread.
    void ConsumerLoop()
    {
        while (!_ending)
        {
            // block until producer signals us
            _signal.WaitOne();
            
            // process whatever is enqueued 
            Something s = null;
            while (!_ending && _concurrentQueue.TryDequeue(out s))
            {
                 Process(s);
            }
        }
    }
