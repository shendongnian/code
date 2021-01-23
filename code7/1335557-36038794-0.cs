    internal class Program
    {
        public interface IJob { }
        public class Job1 : IJob { }
        public class Job2 : IJob { }
        public interface IRepository<out TJob> where TJob : IJob
        {
            IEnumerable<TJob> GetJobs();
        }
        
        public class Repository<TJob> : IRepository<TJob> where TJob : IJob
        {
            public IEnumerable<TJob> GetJobs()
            {
                return new List<TJob>();
            }
        }
        private static void Main(string[] args)
        {
            IJob iJob = new Job1(); // Valid
            IRepository<IJob> repo = new Repository<Job1>(); // Also valid
        }
    }
