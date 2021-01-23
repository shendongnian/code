    public class Job
    {
         public int ExecutionInterval { get; set; }
         public Action Action { get; set; }
    }
    
    public class TimedExecutionHandler
    {
        private List<Job> jobs = new List<Job>();
    
        public void Start()
        {
            // start internal thread on loop
        }
    
        public void Stop()
        {
             // interrupt thread
        }
    
        public void RegisterJob(Job job)
        {
            // store job
        }
    
        private void Loop()
        {
            int count = 0;
            while (true)
            {
                Thread.Sleep(1000);
                count++;
                foreach (Job job in this.jobs)
                {
                    if (count % job.ExecutionInterval == 0)
                    {
                        job.Action();
                    }
                }
            }
        }
    }
