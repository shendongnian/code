    public class MyService
    {
        /// <summary>Queue of actions to be consumed by separate task</summary>
        private ConcurrentQueue<MyObject> queue = new ConcurrentQueue<MyObject>();
    
        private bool _isRunning = false;
        private Task _consumingTask;
    
        public MyService()
        {
        }
    
        public void AddToQueue(MyObject newObject)
        {
            queue.Add(newObject);
        }
    
        private void StartService()
        {
            _isRunning = true;
            Task.Run( async () =>
            {
                while (_isRunning )
                {
                    MyObject myObject;
    
                    while(_isRunning && queue.TryDequeue(out myObject)
                    {
                        try
                        {
                            // Do work...
                        }
                        catch (Exception e)
                        {
                            // Log...
                        }
                    }
                    await Task.Delay(100); // tune this value to one pertinent to your use case 
                }
            });
        }
    
        public void StopService()
        {
            _isRunning = false;
            _consumingTask.Wait();
        }
    }
