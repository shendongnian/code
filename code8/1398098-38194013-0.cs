    public class MainViewModel
    {
        private static void Main()
        {
            Task.Run(() => JobMonitor.Start());
            MainAsync().Wait();
        }
        public async Task MainAsync()
        {
            var test = new string[2];
            var jobs = test.Select(x => randomTask());
            var tasks = jobs.Select(x => x.TCS.Task);
            await Task.WhenAll(tasks);        
        }
        public Job randomTask()
        {
            var job = new Job();
            job.Submit();
            job.TCS.Task.ContinueWith(task => WelcomeTitle += "\n" + DateTime.Now, TaskScheduler.FromCurrentSynchronizationContext());
            return job;
        } 
    }
    public class Job
    {
        public TaskCompletionSource<object> TCS = new TaskCompletionSource<object>();
        public readonly DateTime Expires;
        public bool IsExpired
        {
            get
            {
                var ret = Expires < DateTime.Now;
                return ret;
            }
        }
        public Job()
        {
            Random rnd = new Random();
            System.Threading.Thread.Sleep(20);
            var num = rnd.Next(1, 20);
            Expires = DateTime.Now.AddSeconds(num);
        }
        internal void Submit()
        {
            JobMonitor.SubmitJob(this);
        }
    }
    class JobMonitor
    {
        public static List<Job> activeJobs = new List<Job>();
        private static object _lock = new object();
        public static void SubmitJob(Job job)
        {
            lock(_lock)
            {
                activeJobs.Add(job);
            }
        }
        public static void Start()
        {
            while (true)
            {
                lock (_lock)
                {
                    var expired = activeJobs.Where(job => job.IsExpired).ToList();
                    foreach (var job in expired)
                    {
                        job.TCS.SetResult(null);
                        activeJobs.Remove(job);
                    }
                }
                                
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
