    public class Trade
    {
        
    }
    public interface IRunner
    {
        void Adjust(Trade newfill);
    }
    public class Executor
    {
        private IRunner runner;
        public void Adjust<T>(Trade newFill) where T : class, IRunner, new()
        {
            if(runner == null || (runner as T) == null)
            {
                runner = new T();
            }
            runner.Adjust(newFill);
        }
    }
    public class Runner : IRunner
    {
        public void Adjust(Trade newfill)
        {
            //your logic here.
        }
    }
    public class SynchronizedRunner : IRunner
    {
        private readonly object syncLockObject = new object();
        public void Adjust(Trade newfill)
        {
            lock (syncLockObject)
            {
                //your logic here.
            }
        }
    }
