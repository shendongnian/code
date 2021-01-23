    public delegate void Action();
    public class TaskRunner
    {
        private readonly object _lock = new object();
        private bool _complete;
        private int _counter;
        public void AddTask(Action action)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (sender, args) => action();
            worker.RunWorkerCompleted += (sender, args) =>
            {
                try
                {
                    Monitor.Enter(_lock);
                    if (--_counter == 0)
                    {
                        Monitor.Pulse(_lock);
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            };
            try
            {
                Monitor.Enter(_lock);
                if (_complete)
                {
                    throw new Exception("task runner is complete");
                }
                _counter++;
                worker.RunWorkerAsync();
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
        public void Wait()
        {
            while (!_complete)
            {
                try
                {
                    Monitor.Enter(_lock);
                    if (_counter == 0)
                    {
                        _complete = true;
                        return;
                    }
                    Monitor.Wait(_lock);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
    }
    static void Main(string[] args)
    {
        var task = new TaskRunner();
        for (var i = 0; i < 10; i++)
        {
            task.AddTask(() => 
            { 
                //Do something
            });
        }
        task.Wait();
        Console.WriteLine("Done");
        Console.ReadLine();
    }
