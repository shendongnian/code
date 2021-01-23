    async Task Main()
    {
      var queue = new AsyncConcurrentQueue<int>();
      var task = DequeueAllAsync(queue, i => Console.WriteLine(i));
      
      queue.Enqueue(1);
      queue.Enqueue(2);
      queue.Enqueue(3);
      queue.Enqueue(4);
      queue.Finish();
      
      await task;
    }
    
    private async Task DequeueAllAsync<T>(AsyncConcurrentQueue<T> queue, Action<T> action)
    {
      try
      {
        while (true)
        {
          var value = await queue.TakeAsync(CancellationToken.None);
          
          action(value);
        }
      }
      catch (OperationCanceledException) { }
    }
    
    public class AsyncConcurrentQueue<T>
    {
      private readonly ConcurrentQueue<T> _internalQueue;
      private readonly SemaphoreSlim _newItem;
      private int _isFinished;
      
      public AsyncConcurrentQueue()
      {
        _internalQueue = new ConcurrentQueue<T>();
        _newItem = new SemaphoreSlim(0);
      }
      
      public void Enqueue(T value)
      {
        _internalQueue.Enqueue(value);
        _newItem.Release();
      }
      
      public void Finish()
      {
        Interlocked.Exchange(ref _isFinished, 1);
        _newItem.Release();
      }
      
      public async Task<T> TakeAsync(CancellationToken token)
      {
        while (!token.IsCancellationRequested)
        {
          await _newItem.WaitAsync(token);
          
          token.ThrowIfCancellationRequested();
          
          T result;
          if (_internalQueue.TryDequeue(out result))
          {
            return result;
          }
          
          Interlocked.MemoryBarrier();
          
          if (_isFinished == 1) throw new OperationCanceledException();
        }
        
        throw new OperationCanceledException(token);
      }
    }
