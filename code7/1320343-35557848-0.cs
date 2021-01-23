    public class MyService
    {
        /// <summary>Queue of actions to be consumed on a separate thread</summary>
        private BlockingCollection<MyObject> queue = new BlockingCollection<MyObject>();
        private IEnumerable<Task> readers = Enumerable.Range(0, 10).Select((t) => new Task(() => this.StartService()));
    public MyService()
    {
        StartService();
        readers.AsParallel().ForAll(t => t.Start());
    }
    public void AddToQueue(MyObject newObject)
    {
        queue.Add(newObject);
    }
    private void StartService()
    {
            while (true)
            {
                try
                {
                    MyObject myObject = queue.Take(); // blocks until new object received
                    // Do work...
                }
                catch (Exception e)
                {
                    // Log...
                }
            }
        }
    }
