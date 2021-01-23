    static class Program
    {
        private const int _maxWorkers = 10;
        private static readonly SemaphoreSlim _threadManager = new SemaphoreSlim(_maxWorkers);
        private void DoStuff()
        {
            var queue = new ConcurrentQueue<int>(SomeClass.GetDocumentIds());
            var operations = new List<Task>();
            while (!queue.IsEmpty)
            {
                int documentId;
    
                if (queue.TryDequeue(out documentId))
                {
                    _threadManager.Wait(); // this will block after max number of threads is met
                    try
                    {
                        operations.Add(GetDocument(documentId);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            Task.WaitAll(operations.ToArray()); // finally, this waits till the last remaining tasks are complete
        }
        private static async Task GetDocument(int documentId)
        {
            await Task.Yield();
            
                try
                {
                    GoGetDocument(documentId);
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    _threadManager.Release(); // release the semaphore when the task completes
                }
          
        }
        
