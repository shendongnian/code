    public class Listener
    {
        private ConcurrentQueue<bool> _queue = new ConcurrentQueue<bool>();
        public Listener(NotifyingTaskRunner runner)
        {
            runner.TaskCompleted += Flush;
        }
        public async void Flush(object sender, TaskResultEventArgs e)
        {
            // Enqueue status to flush everything later (or flush it immediately)
            _queue.Enqueue(e.Result);
        }
    }
