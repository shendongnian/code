    public class MyThread
    {
        private ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();
        private void Run()
        {
            Action action;
            if (queue.TryDequeue(out action))
                action();
        }
        public void Connect(Action action)
        {
            queue.Enqueue(action);
        }
    }
