    public class WorkerThread
    {
        public static readonly Queue<Job> jobs = new Queue<Job>();
        public void ThreadFunc()
        {
            while (true)
            {
                if (jobs.Count > 0)
                {
                    Job myJob = jobs.Dequeue()
                    // do something with the job...
                }
                else
                    Thread.Yield();
            }
        }
    }
