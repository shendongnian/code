    public class WorkerThread
    {
        public static readonly ConcurrentQueue<Job> jobs = new ConcurrentQueue<Job>();
        public void ThreadFunc()
        {
            Job myJob;
            while (true)
            {
                if (jobs.TryDequeue(out myJob))
                {
                    // do something with the job...
                }
                else
                    Thread.Yield();
            }
        }
    }
