    public class Worker
    {
        private System.Threading.Timer _timer;
        private int _timeUntilNextCall = 3600000;
        public void Start()
        {
            _timer = new Timer(new TimerCallback(QueuePeek), null, 0, Timeout.Infinite);
        }
        private void QueuePeek(object state)
        {
            int numberOfTasks = 5;
            
            Task[] tasks = new Task[numberOfTasks];
            for(int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = new Task(() =>
                {
                    DoLoad();
                });
                tasks[i].Start();
            }
            // When all tasks are complete, set to run this method again in x milliseconds
            Task.Factory.ContinueWhenAll(tasks, (t) => { _timer.Change(_timeUntilNextCall, Timeout.Infinite); });
        }
        private void DoLoad() { }
    }
