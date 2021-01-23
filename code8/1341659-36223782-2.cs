    public class WorkerThread
    {
        private static object _jobs_lock = new object();
        private static readonly Queue<Job> _jobs = new Queue<Job>();
        public void ThreadFunc()
        {
            Job myJob;
            while (true)
            {
                if ((myJob = NextJob()) != null)
                {
                    // do something with the job...
                }
                else
                    Thread.Yield();
            }
        }
        public void AddJob(Job newJob)
        {
            lock(_jobs_lock)
                _jobs.Enqueue(newJob);
        }
        private Job NextJob()
        {
            lock (_jobs_lock)
            {
                if (_jobs.Count > 0)
                    return _jobs.Dequeue();
            }
            return null;
        }
    }
